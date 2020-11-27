namespace Leonov.BugTracker.Dto
{
    using System;

    /// <summary>
    /// Дто пользователя в проекте.
    /// </summary>
    public class UserInProjectDto
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Дата начала работы в проекте.
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public Guid UserId { get; set; }
    }
}
