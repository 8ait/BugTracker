namespace Leonov.BugTracker.Domain.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Leonov.BugTracker.Domain.Database.SqlServer;
    using Leonov.BugTracker.Domain.Interfaces;
    using Leonov.BugTracker.Domain.Models;

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
    }
}
