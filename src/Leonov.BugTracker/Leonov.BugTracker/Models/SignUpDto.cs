namespace Leonov.BugTracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Дто для регистрации.
    /// </summary>
    public class SignUpDto: IValidatableObject
    {
        /// <summary>
        /// Логин.
        /// </summary>
        [Required(ErrorMessage = "Логин не должен быть пустым.")]
        public string Login { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        [Required(ErrorMessage = "Имя не должно быть пустым.")]
        public string Firstname { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        [Required(ErrorMessage = "Фамилия не должна быть пустой.")]
        public string Surname { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        [Required(ErrorMessage = "Пароль не должен быть пустым.")]
        public string Password { get; set; }

        /// <summary>
        /// Повторение пароля.
        /// </summary>
        [Required(ErrorMessage = "Поле для потворного ввода пароля не должно быть пустым.")]
        public string RepeatPassword { get; set; }

        /// <summary>
        /// Тип пользователя.
        /// </summary>
        [Required(ErrorMessage = "Тип пользователя не должен быть пустым.")]
        public Guid UserTypeId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Password != RepeatPassword)
            {
                yield return new ValidationResult(
                    "Пароли не совпадают.",
                    new[] { nameof(Password), nameof(RepeatPassword) });
            }
        }
    }
}
