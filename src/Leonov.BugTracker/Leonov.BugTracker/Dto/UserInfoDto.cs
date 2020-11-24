namespace Leonov.BugTracker.Dto
{
    using System;

    /// <summary>
    /// Дто инфомрации о пользователе.
    /// </summary>
    public class UserInfoDto
    {
        /// <summary>
        /// Идентификатор.
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
        /// Имя типа пользователя.
        /// </summary>
        public string UserTypeName { get; set; }
    }
}
