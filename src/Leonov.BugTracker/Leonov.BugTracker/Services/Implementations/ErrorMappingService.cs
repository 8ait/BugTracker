﻿namespace Leonov.BugTracker.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;

    using Leonov.BugTracker.Domain.Models;
    using Leonov.BugTracker.Domain.Models.Table;
    using Leonov.BugTracker.Dto;
    using Leonov.BugTracker.Services.Interfaces;

    public class ErrorMappingService: IErrorMappingService
    {
        /// <inheritdoc />
        public TableInfoDto<ErrorInfoDto> TableInfoToTableInfoDto(TableInfo<Error> tableInfo)
        {
            return new TableInfoDto<ErrorInfoDto>()
            {
                Page = tableInfo.Page,
                Count = tableInfo.Count,
                RowDtos = ProjectToProjectInfoDto(tableInfo.Rows).ToList(),
                CountOfPages = tableInfo.CountOfPages
            };
        }

        /// <summary>
        /// Маппинг проекта в дто информации для проекта.
        /// </summary>
        /// <param name="projects"> Проекты. </param>
        /// <returns> Дто информации для проекта. </returns>
        private IEnumerable<ErrorInfoDto> ProjectToProjectInfoDto(List<Error> items)
        {
            foreach (var item in items)
            {
                yield return new ErrorInfoDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    DateTime = item.CreateDate.ToShortDateString(),
                    OriginAreaName = item.OriginArea.Name
                };
            }
        }
    }
}