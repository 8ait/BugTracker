namespace Leonov.BugTracker.Services.Interfaces
{
    using Leonov.BugTracker.Domain.Models;
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
        public ProjectTableInfoDto ProjectTableInfoToProjectTableInfoDto(ProjectTableInfo projectTableInfo);
    }
}
