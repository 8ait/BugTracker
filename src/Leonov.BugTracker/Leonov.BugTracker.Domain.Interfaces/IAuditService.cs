namespace Leonov.BugTracker.Domain.Interfaces
{
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
    }
}
