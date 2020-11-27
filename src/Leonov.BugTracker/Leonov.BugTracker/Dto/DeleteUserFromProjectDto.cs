namespace Leonov.BugTracker.Dto
{
    using System;

    /// <summary>
    /// Удаление пользователя из проекта.
    /// </summary>
    public class DeleteUserFromProjectDto
    {
        /// <summary>
        /// Идентфиикатор пользователя в проекте.
        /// </summary>
        public Guid Id { get; set; }
    }
}
