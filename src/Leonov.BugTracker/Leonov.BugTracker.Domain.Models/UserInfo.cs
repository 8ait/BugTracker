namespace Leonov.BugTracker.Domain.Models
{
    using System;

    /// <summary>
    /// Дто для информации о пользователе.
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// Идентфиикатор пользователя.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Тип пользователя.
        /// </summary>
        public UserType UserType { get; set; }
    }
}
