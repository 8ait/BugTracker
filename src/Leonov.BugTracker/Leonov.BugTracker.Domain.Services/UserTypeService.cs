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
    public class UserTypeService: IUserTypeService
    {
        private readonly BugTrackerContext _context;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="context"> Контекст БД. </param>
        public UserTypeService(BugTrackerContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public List<UserType> GetAll()
        {
            var userTypes = _context.UserTypes;
            return userTypes.ToList();
        }

        /// <inheritdoc />
        public async Task<UserType> GetByIdAsync(int id)
        {
            var user = await _context.UserTypes.FindAsync(id);
            user ??= await _context.UserTypes.FirstOrDefaultAsync();
            return user;
        }
    }
}
