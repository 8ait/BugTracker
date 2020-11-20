namespace Leonov.BugTracker.Domain.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Leonov.BugTracker.Domain.Models;

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
    }
}
