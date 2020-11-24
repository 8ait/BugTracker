namespace Leonov.BugTracker.Domain.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Leonov.BugTracker.Domain.Database.SqlServer;
    using Leonov.BugTracker.Domain.Interfaces;
    using Leonov.BugTracker.Domain.Models;
    using Leonov.BugTracker.Domain.Models.Table;

    using Microsoft.EntityFrameworkCore;

    /// <inheritdoc />
    public class AuditService: IAuditService
    {
        private readonly BugTrackerContext _context;
        private readonly IAuthoriseService _authoriseService;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context"> Контекст. </param>
        public AuditService(BugTrackerContext context, IAuthoriseService authoriseService)
        {
            _context = context;
            _authoriseService = authoriseService;
        }

        /// <inheritdoc />
        public Audit Get(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task EditAsync(List<string> errors, params Audit[] entities)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<TableInfo<Audit>> GetUserAuditTableInfoAsync(int page, int count, List<string> errors)
        {
            var user = await _authoriseService.GetCurrentUser();
            if (user is null)
            {
                errors.Add("Не удалось получить пользователя.");
                return null;
            }

            var auditOfUser = _context.Audits
                .Where(x => x.UserId == user.Id)
                .Include(x => x.ErrorStatus);

            var result = auditOfUser.ToList();
            var table = TableUtil<Audit>.GetTableInfo(page, count, errors, result);

            return table;
        }
    }
}
