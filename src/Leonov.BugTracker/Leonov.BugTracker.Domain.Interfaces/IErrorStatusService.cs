namespace Leonov.BugTracker.Domain.Interfaces
{
    using System.Collections.Generic;

    using Leonov.BugTracker.Domain.Models;

    /// <summary>
    /// Сервсис для взаимодействия со статусами ошибок.
    /// </summary>
    public interface IErrorStatusService
    {
        /// <summary>
        /// Получить все статусы ошибок.
        /// </summary>
        /// <returns>Список статусов ошибок.</returns>
        public List<ErrorStatus> GetAll();
    }
}
