namespace Leonov.BugTracker.Domain.Models
{
    using Leonov.BugTracker.Domain.Models.Base;

    /// <summary>
    /// Статус ошибки.
    /// </summary>
    public class ErrorStatus: BaseDictionaryEntity
    {
        /// <summary>
        /// Активность статуса.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
