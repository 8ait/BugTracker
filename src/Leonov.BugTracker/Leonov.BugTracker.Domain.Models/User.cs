namespace Leonov.BugTracker.Domain.Models
{
    using System;

    using Leonov.BugTracker.Domain.Models.Identity;

    /// <summary>
    /// Пользователь системы.
    /// </summary>
    public class User : BaseEntity
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
        /// Хеш пароля.
        /// </summary>
        public byte[] HashPassword { get; set; }

        /// <summary>
        /// Соль пароля.
        /// </summary>
        public byte[] Salt { get; set; }

        /// <summary>
        /// Сессия куки.
        /// </summary>
        public byte[] CookieSession { get; set; }

        /// <summary>
        /// Идентификатор типа пользователя. 
        /// </summary>
        public Guid UserTypeId { get; set; }

        /// <summary>
        /// Тип пользователя.
        /// </summary>
        public UserType UserType { get; set; }
    }
}
