namespace Leonov.BugTracker.Domain.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Таблица с проектами на определенной странице.
    /// </summary>
    public class ProjectTableInfo
    {
        /// <summary>
        /// Проекты.
        /// </summary>
        public List<Project> Projects { get; set; }

        /// <summary>
        /// Страница.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Число страницы.
        /// </summary>
        public int CountOfPages { get; set; }

        /// <summary>
        /// Количество элементов на странице.
        /// </summary>
        public int Count { get; set; }
    }
}
