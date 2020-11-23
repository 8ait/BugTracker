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
        public Error Get(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task EditAsync(List<string> errors, params Error[] entities)
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
                .Where(x => userInProjectIds.Contains(x.ResponsibleUserId) || userInProjectIds.Contains(x.CreateUserId));

            var result = userErrors.ToList();
            var errorTable = TableUtil<Error>.GetTableInfo(page, count, errors, result);

            return errorTable;
        }
    }
}
