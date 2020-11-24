namespace Leonov.BugTracker.Dto
{
    using System;

    /// <summary>
    /// Дто проекта.
    /// </summary>
    public class ProjectDto
    {
        /// <summary>
        /// Идентификатор проекта.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название проекта.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Опсиание проекта.
        /// </summary>
        public string About { get; set; }
    }
}
