namespace Leonov.BugTracker.Dto
{
    using System;

    /// <summary>
    /// Дто информации о ошибке.
    /// </summary>
    public class ErrorInfoDto
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// название области возникновения.
        /// </summary>
        public string OriginAreaName { get; set; }

        /// <summary>
        /// Дата возникновения.
        /// </summary>
        public string DateTime { get; set; }
    }
}
