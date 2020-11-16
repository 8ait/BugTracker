namespace Leonov.BugTracker.Domain.Database.SqlServer
{
    using Leonov.BugTracker.Domain.Database.SqlServer.Mapping;
    using Leonov.BugTracker.Domain.Models;
    using Leonov.BugTracker.Domain.Models.Identity;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Контекст базы данных баг трекера.
    /// </summary>
    public class BugTrackerContext: DbContext
    {
        /// <summary>
        /// Пользователи.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Типы пользователя.
        /// </summary>
        public DbSet<UserType> UserTypes { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="options"> Опции создания контекста. </param>
        public BugTrackerContext(DbContextOptions<BugTrackerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new UserTypeMap());
        }
    }
}
