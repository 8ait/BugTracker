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

        /// <summary>
        /// Получить количество комментариев пользователя.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<int> GetCountOfUserCommentaries(Guid userId, List<string> errors);

        /// <summary>
        /// Получить популярность пользователя.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<int> GetPopularityOfUser(Guid userId, List<string> errors);
    }
}
