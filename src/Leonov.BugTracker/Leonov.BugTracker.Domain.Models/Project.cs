namespace Leonov.BugTracker.Domain.Models
{
    using System.Collections.Generic;

    using Leonov.BugTracker.Domain.Models.Base;

    /// <summary>
    /// Сущность проекта.
    /// </summary>
    public class Project : BaseEntity
    {
        /// <summary>
        /// Название проекта.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// О проекте.
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// Пользователи в проекте.
        /// </summary>
        public List<UserInProject> UserInProject { get; set; }
    }
}
