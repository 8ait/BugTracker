namespace Leonov.BugTracker.Domain.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Leonov.BugTracker.Domain.Models;

    /// <summary>
    /// Сервис для работы с типами пользователей.
    /// </summary>
    public interface IUserTypeService
    {
        /// <summary>
        /// Получить все типы пользователей.
        /// </summary>
        /// <returns> Список типов пользователей. </returns>
        List<UserType> GetAll();

        /// <summary>
        /// Получить тип пользователя по id.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <returns> Тип пользователя. </returns>
        Task<UserType> GetByIdAsync(int id);
    }
}
