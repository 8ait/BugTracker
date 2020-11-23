namespace Leonov.BugTracker.Domain.Models.Table
{
    using System.Collections.Generic;

    using Leonov.BugTracker.Domain.Models.Base;

    /// <summary>
    /// Таблица с проектами на определенной странице.
    /// </summary>
    public class TableInfo<T> where T: BaseEntity
    {
        /// <summary>
        /// Проекты.
        /// </summary>
        public List<T> Rows { get; set; }

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
