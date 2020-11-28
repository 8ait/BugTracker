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

        /// <summary>
        /// Дто таблицы с проектами.
        /// </summary>
        /// <param name="projectTableInfo"></param>
        /// <returns></returns>
        public TableInfoDto<ErrorFullInfoDto> TableInfoToTableFullInfoDto(TableInfo<Error> tableInfo);

        /// <summary>
        /// Дто создания ошибки в ошибку.
        /// </summary>
        /// <param name="createErrorDto"> Дто создания ошибки. </param>
        /// <returns> Ошибка. </returns>
        public Error CreateErrorDtoToError(CreateErrorDto createErrorDto);
    }
}
