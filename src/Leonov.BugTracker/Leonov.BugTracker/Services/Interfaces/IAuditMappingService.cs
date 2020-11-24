namespace Leonov.BugTracker.Services.Interfaces
{
    using Leonov.BugTracker.Domain.Models;
    using Leonov.BugTracker.Domain.Models.Table;
    using Leonov.BugTracker.Dto;

    /// <summary>
    /// Маппер для аудитов.
    /// </summary>
    public interface IAuditMappingService
    {
        /// <summary>
        /// Маппинг таблицы аудитов в таблицу с информацией аудитов.
        /// </summary>
        /// <param name="tableInfo"> Таблица аудитов. </param>
        /// <returns> Таблица с информацией. </returns>
        public TableInfoDto<AuditInfoDto> TableInfoToTableInfoDto(TableInfo<Audit> tableInfo);
    }
}
