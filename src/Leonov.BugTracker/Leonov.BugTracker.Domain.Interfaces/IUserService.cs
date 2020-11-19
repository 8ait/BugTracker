namespace Leonov.BugTracker.Domain.Interfaces
{
    using System.Collections.Generic;

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
    }
}
