namespace Leonov.BugTracker.Domain.Interfaces
{
    using System;
    using System.Threading.Tasks;

    using Leonov.BugTracker.Domain.Models;

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
        public T Get(Guid id);

        /// <summary>
        /// Удалить сущности.
        /// </summary>
        /// <param name="entities"> Сущности. </param>
        /// <returns></returns>
        public Task EditAsync(params T[] entities);
    }
}
