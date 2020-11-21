namespace Leonov.BugTracker.Dto
{
    using System.Collections.Generic;

    /// <summary>
    /// Информация о таблице проектов.
    /// </summary>
    public class ProjectTableInfoDto
    {
        /// <summary>
        /// Количество страниц.
        /// </summary>
        public int CountOfPages { get; set; }

        /// <summary>
        /// Номер страницы.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Количество cтрок на странице.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Список проектов с инфомрацией на странице.
        /// </summary>
        public List<ProjectInfoDto> ProjectInfoDtos { get; set; }
    }
}
