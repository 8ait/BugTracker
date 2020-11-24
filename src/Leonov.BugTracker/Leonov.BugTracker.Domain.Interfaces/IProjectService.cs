namespace Leonov.BugTracker.Domain.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Leonov.BugTracker.Domain.Models;
    using Leonov.BugTracker.Domain.Models.Table;

    /// <summary>
    /// Сервис для работы с проектами.
    /// </summary>
    public interface IProjectService: IDataService<Project>
    {

        /// <summary>
        /// Получить таблицу с проектами на странице.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="count"> Число элементов на странице. </param>
        /// <returns> Таблица с информацией. </returns>
        public Task<TableInfo<Project>> GetUserProjectTableInfoAsync(int page, int count, List<string> errors, Guid? id = null);

        /// <summary>
        /// Получить таблицу со всеми проектами.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="count"> Количество элементов на страинце. </param>
        /// <param name="errors"> Ошибки. </param>
        /// <returns></returns>
        public Task<TableInfo<Project>> GetProjectAllTableInfoAsync(int page, int count, List<string> errors);
    }
}
