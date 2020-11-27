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
    public class ProjectService : IProjectService
    {
        private readonly BugTrackerContext _context;
        private readonly ILogger _logger;
        private readonly IAuthoriseService _authoriseService;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="logger"> Логгер. </param>
        /// <param name="context"> Контекст. </param>
        public ProjectService(ILogger<ProjectService> logger,
            BugTrackerContext context,
            IAuthoriseService authoriseService)
        {
            _logger = logger;
            _context = context;
            _authoriseService = authoriseService;
        }

        /// <inheritdoc />
        public async Task<Project> GetAsync(Guid id)
        {
            var project = await _context.Projects.FindAsync(id);
            return project;
        }

        /// <inheritdoc />
        public async Task EditAsync(Project entity, List<string> errors)
        {
            _context.Projects.Update(entity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                errors.Add("Не удалось обновить проект в базе данных.");
            }
        }

        /// <inheritdoc />
        public async Task CreateAsync(Project entity, List<string> errors)
        {
            await _context.Projects.AddAsync(entity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                errors.Add("Не удалось добавить проект в базу данных.");
            }
        }

        /// <inheritdoc />
        public async Task DeleteAsync(Guid id, List<string> errors)
        {
            var projectToDelete = await _context.Projects.FindAsync(id);
            if (projectToDelete is null)
            {
                errors.Add("Такого проекта не сущетсвует");
                return;
            }

            var errorsToDelete = _context.Errors.Where(x => x.CreateUser.Project.Id == id);

            _context.Errors.RemoveRange(errorsToDelete);
            _context.Projects.Remove(projectToDelete);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                errors.Add("Не получилось удалить проект из базы данных.");
            }
        }

        /// <inheritdoc />
        public async Task<TableInfo<Project>> GetUserProjectTableInfoAsync(int page, int count, List<string> errors, Guid? id = null)
        {
            User user = null;

            if (id is null)
                user = await _authoriseService.GetCurrentUser();
            else
                user = await _context.Users.FindAsync(id);

            if (user is null)
            {
                errors.Add("Не удалось получить пользователя.");
                return null;
            }

            var projectsOfUser = _context.Projects
                .Join(_context.UserInProjects,
                    project => project.Id,
                    userInProject => userInProject.ProjectId,
                    (project, inProject) => new { Project = project, UserInProject = inProject })
                .Where(x => !x.UserInProject.EndDate.HasValue)
                .Join(_context.Users,
                    arg => arg.UserInProject.UserId,
                    user => user.Id,
                    (an, u) => new {an.Project, u})
                .Where(x => x.u.Id == user.Id)
                .Select(x => x.Project)
                .Distinct()
                .AsNoTracking();

            var result = projectsOfUser.ToList();
            var projectTable = TableUtil<Project>.GetTableInfo(page, count, errors, result);

            return projectTable;
        }

        /// <inheritdoc/>
        public async Task<TableInfo<Project>> GetProjectAllTableInfoAsync(int page, int count, List<string> errors)
        {
            var projects = await _context.Projects.ToListAsync();

            var projectTable = TableUtil<Project>.GetTableInfo(page, count, errors, projects);

            return projectTable;
        }
    }
}
