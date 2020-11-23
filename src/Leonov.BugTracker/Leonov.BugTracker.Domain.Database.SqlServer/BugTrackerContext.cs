namespace Leonov.BugTracker.Domain.Database.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Leonov.BugTracker.Domain.Database.SqlServer.Mapping;
    using Leonov.BugTracker.Domain.Models;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Контекст базы данных баг трекера.
    /// </summary>
    public class BugTrackerContext: DbContext
    {
        /// <summary>
        /// Ошибки.
        /// </summary>
        public DbSet<Error> Errors { get; set; }

        /// <summary>
        /// Аудиты.
        /// </summary>
        public DbSet<Audit> Audits { get; set; }

        /// <summary>
        /// Комментарии.
        /// </summary>
        public DbSet<Commentary> Commentaries { get; set; }

        /// <summary>
        /// Статусы ошибок.
        /// </summary>
        public DbSet<ErrorStatus> ErrorStatuses { get; set; }

        /// <summary>
        /// Области возникновения.
        /// </summary>
        public DbSet<OriginArea> OriginAreas { get; set; }


        /// <summary>
        /// Пользователи.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Типы пользователя.
        /// </summary>
        public DbSet<UserType> UserTypes { get; set; }

        /// <summary>
        /// Пользователи в проектах.
        /// </summary>
        public DbSet<UserInProject> UserInProjects { get; set; }
        
        /// <summary>
        /// Проекты.
        /// </summary>
        public DbSet<Project> Projects { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="options"> Опции создания контекста. </param>
        public BugTrackerContext(DbContextOptions<BugTrackerContext> options) : base(options)
        {
            //Database.Migrate();
        }

        /// <summary>
        /// Попробовать сохранить изменения в БД.
        /// </summary>
        /// <param name="errors"></param>
        public async Task TrySaveChangesAsync(List<string> errors)
        {
            try
            {
                await SaveChangesAsync();
            }
            catch (Exception e)
            {
                errors.Add("Ошибка базы данных.");
            }
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArmMap());
            modelBuilder.ApplyConfiguration(new UserTypeMap());
            modelBuilder.ApplyConfiguration(new OriginAreaMap());
            modelBuilder.ApplyConfiguration(new ErrorStatusMap());
            modelBuilder.ApplyConfiguration(new ProjectMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new UserInProjectMap());
            modelBuilder.ApplyConfiguration(new ErrorMap());
            modelBuilder.ApplyConfiguration(new AuditMap());
            modelBuilder.ApplyConfiguration(new CommentaryMap());
        }
    }
}
