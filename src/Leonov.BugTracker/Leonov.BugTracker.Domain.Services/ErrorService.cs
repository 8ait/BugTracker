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
        private readonly IAuditService _auditService;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context"> Контекст БД. </param>
        public ErrorService(BugTrackerContext context, IAuthoriseService authoriseService, IAuditService auditService)
        {
            _context = context;
            _authoriseService = authoriseService;
            _auditService = auditService;
        }

        /// <inheritdoc />
        public async Task<Error> GetAsync(Guid id)
        {
            var error = await _context.Errors
                .Include(x => x.CreateUser).ThenInclude(u => u.User)
                .Include(x => x.CreateUser).ThenInclude(u => u.Project)
                .Include(x => x.ResponsibleUser).ThenInclude(u => u.User)
                .Include(x => x.OriginArea)
                .Include(x => x.ErrorStatus)
                .FirstOrDefaultAsync(x => x.Id == id);

            return error;
        }

        /// <inheritdoc />
        public async Task EditAsync(Error entity, List<string> errors)
        {
            _context.Errors.Update(entity);
            await _context.TrySaveChangesAsync(errors);
        }

        /// <iheritdoc />
        public async Task CreateAsync(Error entity, List<string> errors)
        {
            _context.Errors.Update(entity);
            await _context.TrySaveChangesAsync(errors);
        }

        /// <inheritdoc />
        public async Task DeleteAsync(Guid id, List<string> errors)
        {
            var errorForDelete = await _context.Errors.FindAsync(id);
            if (errorForDelete is null)
            {
                errors.Add("Ошибка не найдена");
                return;
            }

            _context.Errors.Remove(errorForDelete);
            await _context.TrySaveChangesAsync(errors);
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
        public async Task<TableInfo<Error>> GetErrorAllTableInfoAsync(int page, int count, FilterError filterError, List<string> errors)
        {
            var errorsEnt = await FilterError(_context.Errors, filterError)
                .Include(x => x.CreateUser).ThenInclude(u => u.User)
                .Include(x => x.ResponsibleUser).ThenInclude(u => u.User)
                .Include(x => x.ErrorStatus)
                .Include(x => x.OriginArea)
                .OrderByDescending(x => x.CreateDate)
                .ToListAsync();

            var errorTable = TableUtil<Error>.GetTableInfo(page, count, errors, errorsEnt);

            return errorTable;
        }

        /// <summary>
        /// Применить фильтр.
        /// </summary>
        /// <param name="errors">Ошибки.</param>
        /// <returns></returns>
        private IQueryable<Error> FilterError(DbSet<Error> errors, FilterError filter)
        {
            if (filter is null)
                return errors;

            IQueryable<Error> result = errors;

            if (!string.IsNullOrEmpty(filter.Name))
                result = result.Where(x => EF.Functions.Like(x.Name,$"%{filter.Name}%"));

            if (filter.ErrorOrigin != null)
                result = result.Where(x => x.OriginId == filter.ErrorOrigin);

            if (filter.ErrorStatus != null)
                result = result.Where(x => x.ErrorStatusId == filter.ErrorStatus);

            if (filter.UserCreate != null)
                result = result.Where(x => x.CreateUser.User.Id == filter.UserCreate);

            if (filter.UserResponsible != null)
                result = result.Where(x => x.ResponsibleUser.User.Id == filter.UserResponsible);

            return result;
        }

        /// <inheritdoc />
        public async Task ChangeStatusError(Guid errorId, int errorStatusId, List<string> errors)
        {
            var error = await _context.Errors
                .Include(x => x.ErrorStatus)
                .FirstOrDefaultAsync(x => x.Id == errorId);
            if (error is null)
            {
                errors.Add("Ошибки с таким идентификатором не существует.");
            }

            error.ErrorStatusId = errorStatusId;
            _context.Errors.Update(error);

            await _context.TrySaveChangesAsync(errors);
            if (!errors.Any())
            {
                var errorForAudit = await _context.Errors
                    .Include(x => x.ErrorStatus)
                    .FirstOrDefaultAsync(x => x.Id == errorId);
                var user = await _authoriseService.GetCurrentUser();
                await _auditService.WriteAuditAsync(errorForAudit, user.Id, errors);
            }
        }

        /// <inheritdoc />
        public async Task<int> GetCountOfError(Guid userId, bool isActive, List<string> errors)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user is null)
            {
                errors.Add("Пользвоатель не найден.");
            }

            var comments = _context.Errors
                .Where(x => (x.CreateUser.UserId == userId || x.ResponsibleUser.UserId == userId) &&
                            x.ErrorStatus.IsActive == isActive);

            return comments.Count();
        }
    }
}
