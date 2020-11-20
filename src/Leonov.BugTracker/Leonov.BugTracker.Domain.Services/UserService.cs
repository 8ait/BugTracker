﻿namespace Leonov.BugTracker.Domain.Services
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
    public class UserService: IUserService
    {
        private readonly BugTrackerContext _context;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context"> Контекст БД. </param>
        public UserService(BugTrackerContext context)
        {
            _context = context;
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
            }

            user.FirstName = userInfo.Firstname;
            user.Surname = userInfo.Surname;
            user.UserTypeId = userInfo.UserType.Id;
            await EditAsync(user);
        }

        /// <inheritdoc />
        public User Get(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task EditAsync(params User[] entities)
        {
            _context.Users.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}