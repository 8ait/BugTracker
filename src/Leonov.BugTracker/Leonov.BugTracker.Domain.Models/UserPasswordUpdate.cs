namespace Leonov.BugTracker.Domain.Models
{
    using System;

    /// <summary>
    /// Сущность обновления пароля.
    /// </summary>
    public class UserPasswordUpdate
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Старый пароль.
        /// </summary>
        public string OldPassword { get; set; }

        /// <summary>
        /// Новый пароль.
        /// </summary>
        public string NewPassword { get; set; }
    }
}
