namespace Leonov.BugTracker.Domain.Interfaces
{
    using System;
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

        /// <summary>
        /// Получить таблицу информации о пользователях.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="count"> Количество элементов на странице. </param>
        /// <param name="errors"> Ошибки. </param>
        /// <returns> Таблица информации. </returns>
        public Task<TableInfo<UserInProject>> GetUserTypesTableInfoAsync(int page, int count, Guid id, int UserTypeId, List<string> errors);

        /// <summary>
        /// Получить пользователей по типу пользователя.
        /// </summary>
        /// <param name="userTypeId"> Тип пользователя. </param>
        /// <param name="projectId"> Идентификатор проекта. </param>
        /// <returns></returns>
        public Task<List<User>> GetUsersByUserTypeAndProject(int userTypeId, Guid projectId);

        /// <summary>
        /// Получить польователей по проекту.
        /// </summary>
        /// <param name="projectId">Идентификатор проекта.</param>
        /// <returns></returns>
        public Task<List<UserInProject>> GetUsersByProject(Guid projectId);

        /// <summary>
        /// Доабвить пользователя в проект.
        /// </summary>
        /// <param name="userId"> Идентфикатор пользователя. </param>
        /// <param name="projectId"> Идентфиикатор проекта. </param>
        /// <returns></returns>
        public Task AddUserToProject(Guid userId, Guid projectId, List<string> errors);

        /// <summary>
        /// Удалить пользователя из проекта.
        /// </summary>
        /// <param name="userInProjectId"> Идентификатор пользователя в проекте. </param>
        /// <param name="errors"> Ошибки. </param>
        /// <returns></returns>
        public Task DeleteUserFromProject(Guid userInProjectId, List<string> errors);

        /// <summary>
        /// Получить пользователя в проекте по пользователю и проекту.
        /// </summary>
        /// <param name="userId"> Идентификатор пользователя. </param>
        /// <param name="projectId"> Идентификатор проекта. </param>
        /// <returns> Пользователь в проекте. </returns>
        public Task<UserInProject> GetUserInProjectByUserIdAndProjectId(Guid userId, Guid projectId);
    }
}
