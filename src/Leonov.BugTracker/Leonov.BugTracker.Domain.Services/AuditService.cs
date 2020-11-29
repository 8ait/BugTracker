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
        public Task<Audit> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task EditAsync(Audit entity, List<string> errors)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Audit entity, List<string> errors)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id, List<string> errors)
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

        /// <inheritdoc />
        public async Task<TableInfo<Audit>> GetAuditAllTableInfoAsync(int page, int count, List<string> errors)
        {
            var audits = _context.Audits
                .Include(x => x.User)
                .OrderByDescending(x => x.CreateDate);

            var result = await audits.ToListAsync();
            var table = TableUtil<Audit>.GetTableInfo(page, count, errors, result);

            return table;
        }

        /// <inheritdoc />
        public async Task WriteAuditAsync(Error error, Guid userId, List<string> errors)
        {
            var audit = new Audit()
            {
                ErrorId = error.Id,
                UserId = userId,
                CreateDate = DateTime.Now,
                ErrorStatusId = error.ErrorStatusId,
                About = $"Ошибка \"{error.Name}\" получила статус \"{error.ErrorStatus.Name}\"."
            };

            _context.Audits.Add(audit);

            await _context.TrySaveChangesAsync(errors);
        }
    }
}
