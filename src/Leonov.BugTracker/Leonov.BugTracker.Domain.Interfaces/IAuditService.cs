namespace Leonov.BugTracker.Domain.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Leonov.BugTracker.Domain.Models;
    using Leonov.BugTracker.Domain.Models.Table;

    /// <summary>
    /// Сервис для работы с аудитами.
    /// </summary>
    public interface IAuditService : IDataService<Audit>
    {
        /// <summary>
        /// Получить таблицу информации о аудитах.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="count"> Количество элементов на странице. </param>
        /// <param name="errors"> Ошибки. </param>
        /// <returns> Таблица информации. </returns>
        public Task<TableInfo<Audit>> GetUserAuditTableInfoAsync(int page, int count, List<string> errors);

        /// <summary>
        /// Получить таблицу информации о аудитах.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="count"> Количество элементов на странице. </param>
        /// <param name="errors"> Ошибки. </param>
        /// <returns> Таблица информации. </returns>
        public Task<TableInfo<Audit>> GetAuditAllTableInfoAsync(int page, int count, List<string> errors);

        /// <summary>
        /// Осуществить запись аудита.
        /// </summary>
        /// <param name="errorId"> Идентификатор ошибки. </param>
        /// <param name="newErrorStatus">  </param>
        /// <returns></returns>
        public Task WriteAuditAsync(Error error, Guid userId, List<string> errors);
    }
}
