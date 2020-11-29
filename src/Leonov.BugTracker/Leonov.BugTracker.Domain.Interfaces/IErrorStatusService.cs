namespace Leonov.BugTracker.Domain.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

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

        /// <summary>
        /// Получить статусы ошибки, которые могут у нее быть.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<List<ErrorStatus>> GetErrorStatuses(Guid id, List<string> errors);

        /// <summary>
        /// Получить статус ошибки.
        /// </summary>
        /// <param name="id"> Идентификатор ошибки. </param>
        /// <returns></returns>
        public Task<ErrorStatus> GetErrorStatusOfError(Guid id, List<string> errors);
    }
}
