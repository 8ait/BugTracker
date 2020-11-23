namespace Leonov.BugTracker.Domain.Models.Base
{
    /// <summary>
    /// Базовая сущность словаря.
    /// </summary>
    public class BaseDictionaryEntity
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }
    }
}
