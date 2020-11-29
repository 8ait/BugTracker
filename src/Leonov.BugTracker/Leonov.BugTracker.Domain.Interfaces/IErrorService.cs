namespace Leonov.BugTracker.Domain.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Leonov.BugTracker.Domain.Models;
    using Leonov.BugTracker.Domain.Models.Table;

    /// <summary>
    /// Сервис для работы с ошибками.
    /// </summary>
    public interface IErrorService: IDataService<Error>
    {
        /// <summary>
        /// Получить таблицу с проектами на странице.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="count"> Число элементов на странице. </param>
        /// <returns> Таблица с информацией. </returns>
        public Task<TableInfo<Error>> GetUserErrorTableInfoAsync(int page, int count, List<string> errors);

        /// <summary>
        /// Получить таблицу с проектами на странице.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="count"> Число элементов на странице. </param>
        /// <returns> Таблица с информацией. </returns>
        public Task<TableInfo<Error>> GetProjectErrorTableInfoAsync(int page, int count, Guid id, List<string> errors);

        /// <summary>
        /// Получить таблицу со всеми ошибками.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="count"> Количество элементов на страинце. </param>
        /// <param name="errors"> Ошибки. </param>
        /// <returns></returns>
        public Task<TableInfo<Error>> GetErrorAllTableInfoAsync(int page, int count, List<string> errors);

        /// <summary>
        /// Изменить статус ошибки.
        /// </summary>
        /// <param name="errorId"> Идентификатор ошибки. </param>
        /// <param name="errorStatusId"> Идентификатор статуса ошибки. </param>
        /// <returns></returns>
        public Task ChangeStatusError(Guid errorId, int errorStatusId, List<string> errors);
    }
}
