namespace Leonov.BugTracker.Domain.Database.SqlServer
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Расширения для SQL Server.
    /// </summary>
    public static class SqlServerExtensions
    {
        /// <summary>
        /// Подключить контекст.
        /// </summary>
        /// <param name="services"> Коллекция сервисов. </param>
        /// <param name="connectionString"> Строка подключения. </param>
        public static void UseSqlServerContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BugTrackerContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
