namespace Leonov.BugTracker.Domain.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Leonov.BugTracker.Domain.Models;
    using Leonov.BugTracker.Domain.Models.Table;

    /// <summary>
    /// Сервис для работы с пользователями.
    /// </summary>
    public interface IUserService: IDataService<User>
    {
        /// <summary>
        /// Получить таблицу пользователей.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="count"> Количество записей на странице. </param>
        /// <returns> Таблица пользователей. </returns>
        List<User> GetUserTable(int page, int count);

        /// <summary>
        /// Обновить информацию о пользователе.
        /// </summary>
        /// <param name="userInfo"> Информация о пользователе. </param>
        /// <param name="errors"> Возможные ошибки. </param>
        /// <returns></returns>
        Task UpdateUserInformation(UserInfo userInfo, List<string> errors);

        /// <summary>
        /// Получить таблицу информации о пользователях.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="count"> Количество элементов на странице. </param>
        /// <param name="errors"> Ошибки. </param>
        /// <returns> Таблица информации. </returns>
        public Task<TableInfo<User>> GetUserTableInfoAsync(int page, int count, List<string> errors);
    }
}
