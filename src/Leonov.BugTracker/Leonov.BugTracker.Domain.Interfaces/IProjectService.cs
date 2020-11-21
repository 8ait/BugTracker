namespace Leonov.BugTracker.Domain.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Leonov.BugTracker.Domain.Models;

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
        public Task<ProjectTableInfo> GetUserProjectTableInfoAsync(int page, int count, List<string> errors);
    }
}
