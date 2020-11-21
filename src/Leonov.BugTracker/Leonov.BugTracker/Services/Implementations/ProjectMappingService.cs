namespace Leonov.BugTracker.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;

    using Leonov.BugTracker.Domain.Models;
    using Leonov.BugTracker.Dto;
    using Leonov.BugTracker.Services.Interfaces;

    /// <inheritdoc />
    public class ProjectMappingService : IProjectMappingService
    {
        /// <inheritdoc />
        public ProjectTableInfoDto ProjectTableInfoToProjectTableInfoDto(ProjectTableInfo projectTableInfo)
        {
            return new ProjectTableInfoDto()
            {
                Page = projectTableInfo.Page,
                Count = projectTableInfo.Count,
                ProjectInfoDtos = ProjectToProjectInfoDto(projectTableInfo.Projects).ToList(),
                CountOfPages = projectTableInfo.CountOfPages
            };
        }

        /// <summary>
        /// Маппинг проекта в дто информации для проекта.
        /// </summary>
        /// <param name="projects"> Проекты. </param>
        /// <returns> Дто информации для проекта. </returns>
        private IEnumerable<ProjectInfoDto> ProjectToProjectInfoDto(List<Project> projects)
        {
            foreach (var project in projects)
            {
                yield return new ProjectInfoDto()
                {
                    Id = project.Id,
                    Name = project.Name
                };
            }
        }
    }
}
