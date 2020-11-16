namespace Leonov.BugTracker.Authenticate
{
    using Leonov.BugTracker.Domain.Interfaces;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Расширения для аутентифкации.
    /// </summary>
    public static class AuthExtensions
    {
        /// <summary>
        /// Регистрация сервисов для аутентификации.
        /// </summary>
        /// <param name="services"> Коллекция сервисов. </param>
        public static void AddCustomAuthentication(this IServiceCollection services)
        {
            services.AddScoped<IAuthoriseService, AuthoriseService>();
        }
    }
}
