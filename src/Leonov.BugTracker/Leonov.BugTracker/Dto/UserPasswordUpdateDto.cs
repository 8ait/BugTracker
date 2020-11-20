namespace Leonov.BugTracker.Dto
{
    using System;

    /// <summary>
    /// Дто для обновления пароля.
    /// </summary>
    public class UserPasswordUpdateDto
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

        /// <summary>
        /// Повтор нового пароля.
        /// </summary>
        public string RepeatNewPassword { get; set; }
    }
}
