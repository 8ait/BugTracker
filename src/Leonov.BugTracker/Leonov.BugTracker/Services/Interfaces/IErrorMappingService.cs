namespace Leonov.BugTracker.Services.Interfaces
{
    using Leonov.BugTracker.Domain.Models;
    using Leonov.BugTracker.Domain.Models.Table;
    using Leonov.BugTracker.Dto;

    /// <summary>
    /// Сервис для маппинга ошибок.
    /// </summary>
    public interface IErrorMappingService
    {
        /// <summary>
        /// Дто таблицы с проектами.
        /// </summary>
        /// <param name="projectTableInfo"></param>
        /// <returns></returns>
        public TableInfoDto<ErrorInfoDto> TableInfoToTableInfoDto(TableInfo<Error> tableInfo);
    }
}
