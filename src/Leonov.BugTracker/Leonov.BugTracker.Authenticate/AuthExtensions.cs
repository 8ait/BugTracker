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
        /// Использовать кастомную аутентификацию.
        /// </summary>
        /// <param name="app"> </param>
        public static void UseCustomAuthentication(this IApplicationBuilder app)
        {
            //app.UseMiddleware<AuthMiddleware>();

            /*app.Use(async (context, func) =>
            {
                await func();
                if (context.Response.StatusCode == 403)
                {
                    context.Request.Path = "/Auth/Forbidden";
                }
                else if (context.Response.StatusCode == 401)
                {
                    context.Request.Path = "/Auth";
                }
            });*/
        }

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
