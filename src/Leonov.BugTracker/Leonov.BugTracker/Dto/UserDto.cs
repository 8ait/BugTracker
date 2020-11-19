namespace Leonov.BugTracker.Dto
{
    using System;

    /// <summary>
    /// Дто пользователя.
    /// </summary>
    public class UserDto
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
        /// Тип пользователя.
        /// </summary>
        public string UserTypeName { get; set; }
    }
}
