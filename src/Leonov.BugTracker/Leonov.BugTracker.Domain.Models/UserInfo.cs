namespace Leonov.BugTracker.Domain.Models
{
    using Leonov.BugTracker.Domain.Models.Base;

    /// <summary>
    /// Дто для информации о пользователе.
    /// </summary>
    public class UserInfo: BaseEntity
    {
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
