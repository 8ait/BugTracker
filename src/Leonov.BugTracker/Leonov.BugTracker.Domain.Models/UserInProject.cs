namespace Leonov.BugTracker.Domain.Models
{
    using System;

    /// <summary>
    /// Пользователь в проекте.
    /// </summary>
    public class UserInProject : BaseEntity
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Идентификатор проекта.
        /// </summary>
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Проект.
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// Дата начала работы в проекте.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата конца работы в проекте.
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
}
