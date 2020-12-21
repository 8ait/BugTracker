namespace Leonov.BugTracker.Domain.Models
{
    using System;

    /// <summary>
    /// Фильтер для ошибки.
    /// </summary>
    public class FilterError
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Статус ошибки.
        /// </summary>
        public int? ErrorStatus { get; set; }

        /// <summary>
        /// Область возникновения.
        /// </summary>
        public int? ErrorOrigin { get; set; }

        /// <summary>
        /// Создатель ошибки.
        /// </summary>
        public Guid? UserCreate { get; set; }

        /// <summary>
        /// Ответсвенный за ошибку.
        /// </summary>
        public Guid? UserResponsible { get; set; }
    }
}
