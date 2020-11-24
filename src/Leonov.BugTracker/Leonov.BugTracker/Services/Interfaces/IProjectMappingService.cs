namespace Leonov.BugTracker.Services.Interfaces
{
    using Leonov.BugTracker.Domain.Models;
    using Leonov.BugTracker.Domain.Models.Table;
    using Leonov.BugTracker.Dto;

    /// <summary>
    /// Сервис для маппинга проектов.
    /// </summary>
    public interface IProjectMappingService
    {
        /// <summary>
        /// Дто таблицы с проектами.
        /// </summary>
        /// <param name="projectTableInfo"></param>
        /// <returns></returns>
        public TableInfoDto<ProjectInfoDto> TableInfoToTableInfoDto(TableInfo<Project> tableInfo);

        /// <summary>
        /// Проект в дто проекта.
        /// </summary>
        /// <param name="project"> Проект. </param>
        /// <returns> Дто проекта. </returns>
        public ProjectDto ProjectToProjectDto(Project project);

        /// <summary>
        /// Дто создания проекта в проект.
        /// </summary>
        /// <param name="createProjectDto"> Дто создания проекта. </param>
        /// <returns> Проект. </returns>
        public Project CreateProjectDtoToProject(CreateProjectDto createProjectDto);

        /// <summary>
        /// Дто редактирования проекта.
        /// </summary>
        /// <param name="editProjectDto"> Дто редактирования проекта. </param>
        /// <returns> Проект. </returns>
        public Project EditProjectDtoToProject(EditProjectDto editProjectDto);

        /// <summary>
        /// Проект в дто редактирования проекта.
        /// </summary>
        /// <param name="project"> Проект. </param>
        /// <returns> Дто редактирвоания. </returns>
        public EditProjectDto ProjectToEditProjectDto(Project project);
    }
}
