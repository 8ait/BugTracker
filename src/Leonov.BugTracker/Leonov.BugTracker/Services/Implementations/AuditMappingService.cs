namespace Leonov.BugTracker.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;

    using Leonov.BugTracker.Domain.Models;
    using Leonov.BugTracker.Domain.Models.Table;
    using Leonov.BugTracker.Dto;
    using Leonov.BugTracker.Services.Interfaces;

    /// <inheritdoc />
    public class AuditMappingService: IAuditMappingService
    {
        /// <inheritdoc />
        public TableInfoDto<AuditInfoDto> TableInfoToTableInfoDto(TableInfo<Audit> tableInfo)
        {
            return new TableInfoDto<AuditInfoDto>()
            {
                Page = tableInfo.Page,
                Count = tableInfo.Count,
                RowDtos = AuditToAuditInfoDto(tableInfo.Rows).ToList(),
                CountOfPages = tableInfo.CountOfPages
            };
        }

        /// <summary>
        /// Маппинг аудита в дто информации для аудита.
        /// </summary>
        /// <param name="items"> Аудиты. </param>
        /// <returns> Дто информации для аудита. </returns>
        private IEnumerable<AuditInfoDto> AuditToAuditInfoDto(List<Audit> items)
        {
            foreach (var item in items)
            {
                yield return new AuditInfoDto()
                {
                    Id = item.Id,
                    About = item.About,
                    CreateDate = item.CreateDate.ToShortDateString(),
                    ErrorStatusName = item.ErrorStatus.Name
                };
            }
        }
    }
}
