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
    public class ErrorService: IErrorService
    {
        private readonly BugTrackerContext _context;
        private readonly IAuthoriseService _authoriseService;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context"> Контекст БД. </param>
        public ErrorService(BugTrackerContext context, IAuthoriseService authoriseService)
        {
            _context = context;
            _authoriseService = authoriseService;
        }

        /// <inheritdoc />
        public Task<Error> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task EditAsync(Error entity, List<string> errors)
        {
            throw new NotImplementedException();
        }

        /// <iheritdoc />
        public async Task CreateAsync(Error entity, List<string> errors)
        {
            _context.Errors.Update(entity);
            await _context.TrySaveChangesAsync(errors);
        }

        public Task DeleteAsync(Guid id, List<string> errors)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<TableInfo<Error>> GetUserErrorTableInfoAsync(int page, int count, List<string> errors)
        {
            var user = await _authoriseService.GetCurrentUser();
            if (user == null)
            {
                errors.Add("Не удалось получить пользователя.");
                return null;
            }

            var userInProjectIds = _context.UserInProjects
                .Where(x => x.UserId == user.Id)
                .Select(x => x.Id);

            var userErrors = _context.Errors
                .Include(x => x.OriginArea)
                .Where(x => userInProjectIds.Contains(x.ResponsibleUserId) || userInProjectIds.Contains(x.CreateUserId))
                .OrderByDescending(x => x.CreateDate);

            var result = userErrors.ToList();
            var errorTable = TableUtil<Error>.GetTableInfo(page, count, errors, result);

            return errorTable;
        }

        /// <inheritdoc />
        public async Task<TableInfo<Error>> GetProjectErrorTableInfoAsync(int page, int count, Guid id, List<string> errors)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project is null)
            {
                errors.Add("Не удалось получить проект.");
            }

            var userInProjectIds = _context.UserInProjects
                .Where(x => x.ProjectId == project.Id)
                .Select(x => x.Id);

            var projectErrors = _context.Errors
                .Include(x => x.OriginArea)
                .Where(x => userInProjectIds.Contains(x.CreateUserId))
                .OrderByDescending(x => x.CreateDate);

            var result = projectErrors.ToList();
            var projectErrorTable = TableUtil<Error>.GetTableInfo(page, count, errors, result);

            return projectErrorTable;
        }

        /// <inheritdoc />
        public async Task<TableInfo<Error>> GetErrorAllTableInfoAsync(int page, int count, List<string> errors)
        {
            var errorsEnt = await _context.Errors
                .Include(x => x.CreateUser).ThenInclude(u => u.User)
                .Include(x => x.ResponsibleUser).ThenInclude(u => u.User)
                .Include(x => x.ErrorStatus)
                .Include(x => x.OriginArea)
                .OrderByDescending(x => x.CreateDate)
                .ToListAsync();

            var errorTable = TableUtil<Error>.GetTableInfo(page, count, errors, errorsEnt);

            return errorTable;
        }
    }
}
