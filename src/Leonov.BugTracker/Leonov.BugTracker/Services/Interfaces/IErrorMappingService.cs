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

        /// <summary>
        /// Ошибку в дто ошибки.
        /// </summary>
        /// <param name="error"> Ошибка. </param>
        /// <returns></returns>
        public ErrorDto ErrorToErrorDto(Error error);

        /// <summary>
        /// Ошибку в дто редактирования ошибки.
        /// </summary>
        /// <param name="error"> Ошибка. </param>
        /// <returns></returns>
        public EditErrorDto ErrorToEditErrorDto(Error error);

        /// <summary>
        /// Дто редактирования ошибки в ошибку.
        /// </summary>
        /// <param name="editErrorDto"> Дто редактирования ошибки. </param>
        /// <returns></returns>
        public Error EditErrorDtoToError(EditErrorDto editErrorDto);
    }
}
