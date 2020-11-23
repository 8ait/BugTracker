﻿namespace Leonov.BugTracker.Services.Implementations
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
