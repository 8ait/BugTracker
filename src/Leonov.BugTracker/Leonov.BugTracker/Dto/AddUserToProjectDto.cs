namespace Leonov.BugTracker.Dto
{
    using System;

    /// <summary>
    /// Дто добавления пользователя в проект.
    /// </summary>
    public class AddUserToProjectDto
    {
        /// <summary>
        /// Идентфикатор пользователя.
        /// </summary>
        public Guid User { get; set; }

        /// <summary>
        /// Идентификатор проекта.
        /// </summary>
        public Guid Project { get; set; }
    }
}
