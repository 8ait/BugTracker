namespace Leonov.BugTracker.Domain.Models
{
    /// <summary>
    /// Данные для входа.
    /// </summary>
    public class SignIn
    {
        /// <summary>
        /// Логин.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }
    }
}
