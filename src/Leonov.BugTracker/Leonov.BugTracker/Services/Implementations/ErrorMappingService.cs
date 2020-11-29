namespace Leonov.BugTracker.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Leonov.BugTracker.Domain.Models;
    using Leonov.BugTracker.Domain.Models.Table;
    using Leonov.BugTracker.Dto;
    using Leonov.BugTracker.Services.Interfaces;

    /// <inheritdoc />
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

        /// <inheritdoc />
        public ErrorDto ErrorToErrorDto(Error error)
        {
            return new ErrorDto()
            {
                Id = error.Id,
                Name = error.Name,
                About = error.About,
                ProjectName = error.CreateUser.Project.Name,
                CreateUserName = $"{error.CreateUser.User.FirstName} {error.CreateUser.User.Surname}",
                ResponsibleUserName = $"{error.ResponsibleUser.User.FirstName} {error.ResponsibleUser.User.Surname}",
                OriginAreaName = error.OriginArea.Name,
                ErrorStatusName = error.ErrorStatus.Name,
                CreateDateTime = error.CreateDate.ToLongDateString()
            };
        }

        /// <inheritdoc />
        public EditErrorDto ErrorToEditErrorDto(Error error)
        {
            return new EditErrorDto()
            {
                Id = error.Id,
                Name = error.Name,
                About = error.About,
                ProjectId = error.CreateUser.ProjectId,
                CreateUserId = error.CreateUserId,
                ProjectName = error.CreateUser.Project.Name,
                CreateDate = error.CreateDate,
                ResponsibleUserId = error.ResponsibleUserId,
                ErrorStatusId = error.ErrorStatusId,
                CreateUserName = $"{error.CreateUser.User.FirstName} {error.CreateUser.User.Surname}",
                OriginAreaId = error.OriginId
            };
        }

        /// <inheritdoc />
        public Error EditErrorDtoToError(EditErrorDto editErrorDto)
        {
            return new Error()
            {
                Id = editErrorDto.Id,
                Name = editErrorDto.Name,
                About = editErrorDto.About,
                CreateUserId = editErrorDto.CreateUserId,
                CreateDate = editErrorDto.CreateDate,
                ErrorStatusId = editErrorDto.ErrorStatusId,
                OriginId = editErrorDto.OriginAreaId,
                ResponsibleUserId = editErrorDto.ResponsibleUserId
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
