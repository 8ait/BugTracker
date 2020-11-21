namespace Leonov.BugTracker.Domain.Models
{
    /// <summary>
    /// Сущность обновления пароля.
    /// </summary>
    public class UserPasswordUpdate : BaseEntity
    {
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
