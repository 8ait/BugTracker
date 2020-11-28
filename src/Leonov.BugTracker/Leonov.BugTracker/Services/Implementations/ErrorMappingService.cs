namespace Leonov.BugTracker.Services.Implementations
{
    using System;
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
                RowDtos = ErrorToErrorInfoDto(tableInfo.Rows).ToList(),
                CountOfPages = tableInfo.CountOfPages
            };
        }

        /// <inheritdoc />
        public TableInfoDto<ErrorFullInfoDto> TableInfoToTableFullInfoDto(TableInfo<Error> tableInfo)
        {
            return new TableInfoDto<ErrorFullInfoDto>()
            {
                Page = tableInfo.Page,
                Count = tableInfo.Count,
                RowDtos = ErrorToErrorFullInfoDto(tableInfo.Rows).ToList(),
                CountOfPages = tableInfo.CountOfPages
            };
        }

        /// <inheritdoc />
        public Error CreateErrorDtoToError(CreateErrorDto createErrorDto)
        {
            return new Error()
            {
                Name = createErrorDto.Name,
                About = createErrorDto.About,
                CreateUserId = createErrorDto.CreateUserId,
                ErrorStatusId = createErrorDto.ErrorStatusId,
                OriginId = createErrorDto.OriginAreaId,
                ResponsibleUserId = createErrorDto.ResponsibleUserId,
                CreateDate = DateTime.Now
            };
        }

        /// <summary>
        /// Маппинг проекта в дто информации для проекта.
        /// </summary>
        /// <param name="projects"> Проекты. </param>
        /// <returns> Дто информации для проекта. </returns>
        private IEnumerable<ErrorInfoDto> ErrorToErrorInfoDto(List<Error> items)
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

        /// <summary>
        /// Маппинг проекта в дто информации для проекта.
        /// </summary>
        /// <param name="projects"> Проекты. </param>
        /// <returns> Дто информации для проекта. </returns>
        private IEnumerable<ErrorFullInfoDto> ErrorToErrorFullInfoDto(List<Error> items)
        {
            foreach (var item in items)
            {
                yield return new ErrorFullInfoDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    CreateUserName = $"{item.CreateUser.User.FirstName} {item.CreateUser.User.Surname}",
                    ErrorStatusName = item.ErrorStatus.Name,
                    OriginAreaName = item.OriginArea.Name,
                    ResponsibleUserName = $"{item.ResponsibleUser.User.FirstName} {item.ResponsibleUser.User.Surname}",
                    CreateDate = item.CreateDate.ToShortDateString()
                };
            }
        }
    }
}
