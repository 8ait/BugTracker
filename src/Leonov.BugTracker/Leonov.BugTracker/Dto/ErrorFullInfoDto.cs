namespace Leonov.BugTracker.Dto
{
    using System;

    /// <summary>
    /// Дто информации ошибки для полной таблицы.
    /// </summary>
    public class ErrorFullInfoDto
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
        /// Дата создания.
        /// </summary>
        public string CreateDate { get; set; }

        /// <summary>
        /// Название области возникновения.
        /// </summary>
        public string OriginAreaName { get; set; }

        /// <summary>
        /// Название статуса ошибки.
        /// </summary>
        public string ErrorStatusName { get; set; }

        /// <summary>
        /// Имя создателя.
        /// </summary>
        public string CreateUserName { get; set; }

        /// <summary>
        /// Имя ответсвенного.
        /// </summary>
        public string ResponsibleUserName { get; set; }
    }
}
