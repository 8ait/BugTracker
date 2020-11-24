namespace Leonov.BugTracker
{
    using Leonov.BugTracker.Authenticate;
    using Leonov.BugTracker.Domain.Database.SqlServer;
    using Leonov.BugTracker.Domain.Interfaces;
    using Leonov.BugTracker.Domain.Services;
    using Leonov.BugTracker.Services.Implementations;
    using Leonov.BugTracker.Services.Interfaces;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connString = Configuration.GetSection("ConnectionString").Get<string>();
            services.UseSqlServerContext(connString);

            services.AddLogging();
            services.AddScoped<IUserTypeService, UserTypeService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IErrorService, ErrorService>();
            services.AddScoped<IAuditService, AuditService>();

            RegisterMappingServices(services);

            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddCustomAuthentication();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        /// <summary>
        /// Регистрация маппинг сервисов.
        /// </summary>
        /// <param name="services"> Коллекция сервисов. </param>
        private void RegisterMappingServices(IServiceCollection services)
        {
            services.AddScoped<IAuthoriseMappingService, AuthoriseMappingService>();
            services.AddScoped<IUserMappingService, UserMappingService>();
            services.AddScoped<IProjectMappingService, ProjectMappingService>();
            services.AddScoped<IErrorMappingService, ErrorMappingService>();
            services.AddScoped<IAuditMappingService, AuditMappingService>();
        }
    }
}
