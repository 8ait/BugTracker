namespace Leonov.BugTracker.Domain.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Leonov.BugTracker.Domain.Database.SqlServer;
    using Leonov.BugTracker.Domain.Interfaces;
    using Leonov.BugTracker.Domain.Models;

    using Microsoft.EntityFrameworkCore;

    /// <inheritdoc />
    public class ErrorStatusService: IErrorStatusService
    {
        private readonly BugTrackerContext _context;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        public ErrorStatusService(BugTrackerContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public List<ErrorStatus> GetAll()
        {
            var errorStatuses = _context.ErrorStatuses.ToList();
            return errorStatuses;
        }

        /// <inheritdoc />
        public async Task<List<ErrorStatus>> GetErrorStatuses(Guid id, List<string> errors)
        {
            var error = await _context.Errors.FindAsync(id);
            if (error is null)
            {
                errors.Add("ошибки с таким идентификаторо не сущетсвует.");
            }

            var errorStatusId = error.ErrorStatusId;

            var errorStatuses = _context.ErrorStatuses.Where(x => x.Id != errorStatusId);

            return errorStatuses.ToList();
        }

        /// <iheritdoc />
        public async Task<ErrorStatus> GetErrorStatusOfError(Guid id, List<string> errors)
        {
            var error = await _context.Errors
                .Include(x => x.ErrorStatus)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (error is null)
            {
                errors.Add("ошибки с таким идентификаторо не сущетсвует.");
                return null;
            }

            return error.ErrorStatus;
        }
    }
}
