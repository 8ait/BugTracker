namespace Leonov.BugTracker.Dto
{
    using System.ComponentModel.DataAnnotations;

    using Leonov.BugTracker.Domain.Models;

    /// <summary>
    /// Дто для информации о пользователе.
    /// </summary>
    public class UserInfoDto
    {
        /// <summary>
        /// Имя.
        /// </summary>
        [Required]
        public string Firstname { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        [Required]
        public string Surname { get; set; }

        /// <summary>
        /// Тип пользователя.
        /// </summary>
        [Required]
        public UserType UserType { get; set; }
    }
}
