namespace Leonov.BugTracker.Domain.Models.Identity
{
    /// <summary>
    /// Данные для регистрации.
    /// </summary>
    public class SignUp
    {
        /// <summary>
        /// Логин.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Тип пользователя.
        /// </summary>
        public UserType UserType { get; set; }
    }
}
