namespace Leonov.BugTracker.Domain.Models
{
    using System;

    using Leonov.BugTracker.Domain.Models.Base;

    /// <summary>
    /// Аудит.
    /// </summary>
    public class Audit: BaseEntity
    {
        /// <summary>
        /// Описание.
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Статус ошибки.
        /// </summary>
        public ErrorStatus ErrorStatus { get; set; }

        /// <summary>
        /// Ид статуса ошибки.
        /// </summary>
        public int ErrorStatusId { get; set; }

        /// <summary>
        /// Пользователь, изменивший ошибку.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// ID пользователя.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Ошибка.
        /// </summary>
        public Error Error { get; set; }

        /// <summary>
        /// ИД ошибки.
        /// </summary>
        public Guid ErrorId { get; set; }
    }
}
