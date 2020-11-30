namespace Leonov.BugTracker.Domain.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Leonov.BugTracker.Domain.Models;

    /// <summary>
    /// Сервис для работы с комментариями.
    /// </summary>
    public interface ICommentaryService: IDataService<Commentary>
    {
        /// <summary>
        /// Получить список комментариев по Id.
        /// </summary>
        /// <param name="errorId"></param>
        /// <returns></returns>
        public Task<List<Commentary>> GetCommentariesByError(Guid errorId, List<string> errors);
    }
}
