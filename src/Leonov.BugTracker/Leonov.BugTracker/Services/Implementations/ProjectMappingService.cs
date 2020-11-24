namespace Leonov.BugTracker.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;

    using Leonov.BugTracker.Domain.Models;
    using Leonov.BugTracker.Domain.Models.Table;
    using Leonov.BugTracker.Dto;
    using Leonov.BugTracker.Services.Interfaces;

    /// <inheritdoc />
    public class ProjectMappingService : IProjectMappingService
    {
        /// <inheritdoc />
        public TableInfoDto<ProjectInfoDto> TableInfoToTableInfoDto(TableInfo<Project> tableInfo)
        {
            return new TableInfoDto<ProjectInfoDto>()
            {
                Page = tableInfo.Page,
                Count = tableInfo.Count,
                RowDtos = ProjectToProjectInfoDto(tableInfo.Rows).ToList(),
                CountOfPages = tableInfo.CountOfPages
            };
        }

        /// <inheritdoc />
        public ProjectDto ProjectToProjectDto(Project project)
        {
            return new ProjectDto()
            {
                Id = project.Id,
                Name = project.Name,
                About = project.About
            };
        }

        /// <inheritdoc />
        public Project CreateProjectDtoToProject(CreateProjectDto createProjectDto)
        {
            return new Project()
            {
                Name = createProjectDto.Name,
                About = createProjectDto.About
            };
        }

        /// <inheritdoc />
        public Project EditProjectDtoToProject(EditProjectDto editProjectDto)
        {
            return new Project()
            {
                Id = editProjectDto.Id,
                Name = editProjectDto.Name,
                About = editProjectDto.About
            };
        }

        /// <inheritdoc />
        public EditProjectDto ProjectToEditProjectDto(Project project)
        {
            return new EditProjectDto()
            {
                Id = project.Id,
                Name = project.Name,
                About = project.About
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
