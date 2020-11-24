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
    using Microsoft.Extensions.Logging;

    /// <inheritdoc />
    public class UserService: IUserService
    {
        private readonly ILogger _logger;
        private readonly BugTrackerContext _context;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context"> Контекст БД. </param>
        /// <param name="logger"> Логгер. </param>
        public UserService(BugTrackerContext context, ILogger<UserService> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <inheritdoc />
        public List<User> GetUserTable(int page, int count)
        {
            var users = _context.Users
                .Include(x => x.UserType)
                .AsNoTracking()
                .ToList();
            var pages = users.Count / count + (users.Count % count == 0 ? 0 : 1);
            var result = new List<User>();
            for (var i = (page - 1) * count; i < page * count && i < users.Count; i++)
            {
                result.Add(users[i]);
            }

            return result;
        }

        /// <inheritdoc />
        public async Task UpdateUserInformation(UserInfo userInfo, List<string> errors)
        {
            var user = await _context.Users
                .Include(u => u.UserType)
                .FirstOrDefaultAsync(u => u.Id == userInfo.Id);

            if (user is null)
            {
                errors.Add("Такого пользователя не существует.");
                return;
            }

            user.FirstName = userInfo.Firstname;
            user.Surname = userInfo.Surname;
            user.UserTypeId = userInfo.UserType.Id;

            await EditAsync(user, errors);
        }

        /// <inheritdoc />
        public async Task<TableInfo<User>> GetUserTableInfoAsync(int page, int count, List<string> errors)
        {
            var users = _context.Users
                .Include(x => x.UserType);
            var result = await users.ToListAsync();

            var table = TableUtil<User>.GetTableInfo(page, count, errors, result);

            return table;
        }

        /// <inheritdoc />
        public async Task<User> GetAsync(Guid id)
        {
            var user = await _context.Users
                .Include(x => x.UserType)
                .FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        /// <inheritdoc />
        public async Task EditAsync(User entity, List<string> errors)
        {
            _context.Users.Update(entity);
            await _context.TrySaveChangesAsync(errors);
        }

        public Task CreateAsync(User entity, List<string> errors)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id, List<string> errors)
        {
            throw new NotImplementedException();
        }

        private IQueryable<User> IncludeCommon(IQueryable<User> users)
        {
            users.Include(x => x.UserType);
            return users;
        }
    }
}
