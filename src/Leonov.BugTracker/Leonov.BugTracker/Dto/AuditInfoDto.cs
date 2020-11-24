namespace Leonov.BugTracker.Dto
{
    using System;

    /// <summary>
    /// Дто информации о аудите.
    /// </summary>
    public class AuditInfoDto
    {
        /// <summary>
        /// Идентификатор аудита.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Информация о аудите.
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// Дата создания аудита.
        /// </summary>
        public string CreateDate { get; set; }

        /// <summary>
        /// Имя статуса ошибки.
        /// </summary>
        public string ErrorStatusName { get; set; }
    }
}
