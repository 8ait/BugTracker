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
        public Project Get(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task EditAsync(params Project[] entities)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<ProjectTableInfo> GetUserProjectTableInfoAsync(int page, int count, List<string> errors)
        {
            var user = await _authoriseService.GetCurrentUser();
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
                .Join(_context.Users,
                    arg => arg.UserInProject.UserId,
                    user => user.Id,
                    (an, u) => new {an.Project, u})
                .Where(x => x.u.Id == user.Id)
                .Select(x => x.Project)
                .Distinct()
                .AsNoTracking();

            var result = projectsOfUser.ToList();
            var countOfPages = result.Count % count == 0 && result.Count != 0 ? result.Count / count : result.Count / count + 1;

            if (page > countOfPages)
            {
                errors.Add("Запрашиваемая страница не существует.");
                return null;
            }

            var projectTable = new ProjectTableInfo()
            {
                Projects = new List<Project>(),
                Count = count,
                CountOfPages = countOfPages,
                Page = page
            };

            for (int i = (page - 1) * count; i < result.Count && i < page * count; i++)
            {
                projectTable.Projects.Add(result[i]);
            }

            return projectTable;
        }
    }
}
