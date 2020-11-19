namespace Leonov.BugTracker.Dto
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Дто входа.
    /// </summary>
    public class SignInDto
    {
        /// <summary>
        /// Логин.
        /// </summary>
        [Required(ErrorMessage = "Логин не должен быть пустым.")]
        public string Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        [Required(ErrorMessage = "Пароль не должен быть пустым.")]
        public string Password { get; set; }
    }
}
