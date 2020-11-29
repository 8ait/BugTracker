namespace Leonov.BugTracker.Dto
{
    using System;

    /// <summary>
    /// Информация для полной таблицы аудитов.
    /// </summary>
    public class AuditFullInfoDto
    {
        /// <summary>
        /// Информация.
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public string CreateDate { get; set; }

        /// <summary>
        /// Имя создателя.
        /// </summary>
        public string CreateUserName { get; set; }
    }
}
