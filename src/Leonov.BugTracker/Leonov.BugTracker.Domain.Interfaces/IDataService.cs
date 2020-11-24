namespace Leonov.BugTracker.Domain.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Leonov.BugTracker.Domain.Models.Base;

    /// <summary>
    /// Предоставляет работу со слоем данных.
    /// </summary>
    public interface IDataService<T> where T : BaseEntity
    {
        /// <summary>
        /// Получить сущность.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <returns> Сущность. </returns>
        public Task<T> GetAsync(Guid id);

        /// <summary>
        /// Редактировать сущности.
        /// </summary>
        /// <param name="entities"> Сущности. </param>
        /// <returns></returns>
        public Task EditAsync(List<string> errors, params T[] entities);
    }
}
