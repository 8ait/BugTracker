namespace Leonov.BugTracker.Domain.Models
{
    using System;

    using Leonov.BugTracker.Domain.Models.Base;

    /// <summary>
    /// Комментарий.
    /// </summary>
    public class Commentary: BaseEntity
    {
        /// <summary>
        /// Значение.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Родительский комментарий.
        /// </summary>
        public Commentary Parent { get; set; }

        /// <summary>
        /// Идентифиактор родительского комментария.
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// Ошибка.
        /// </summary>
        public Error Error { get; set; }

        /// <summary>
        /// Идентификатор ошибки.
        /// </summary>
        public Guid ErrorId { get; set; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Ид пользвателя.
        /// </summary>
        public Guid UserId { get; set; }
    }
}
