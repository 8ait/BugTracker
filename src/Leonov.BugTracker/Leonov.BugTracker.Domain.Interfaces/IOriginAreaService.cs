namespace Leonov.BugTracker.Domain.Interfaces
{
    using System.Collections.Generic;

    using Leonov.BugTracker.Domain.Models;

    /// <summary>
    /// Сервис дял взаимодействия с областями возникновения ошибки.
    /// </summary>
    public interface IOriginAreaService
    {
        /// <summary>
        /// Получить все возможные области возникновения.
        /// </summary>
        /// <returns> Список областей возникновения. </returns>
        public List<OriginArea> GetAll();
    }
}
