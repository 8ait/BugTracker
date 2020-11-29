namespace Leonov.BugTracker.Dto
{
    using System;

    /// <summary>
    /// Дто ошибки.
    /// </summary>
    public class ErrorDto
    {
        /// <summary>
        /// Идентификатор ошибки.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название проекта.
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Имя ошибки.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание ошибки.
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// Время создания ошибки.
        /// </summary>
        public string CreateDateTime { get; set; }

        /// <summary>
        /// Название области возникновения ошибки.
        /// </summary>
        public string OriginAreaName { get; set; }

        /// <summary>
        /// Названия статуса ошибки.
        /// </summary>
        public string ErrorStatusName { get; set; }

        /// <summary>
        /// Имя создателя.
        /// </summary>
        public string CreateUserName { get; set; }

        /// <summary>
        /// Имя ответственного.
        /// </summary>
        public string ResponsibleUserName { get; set; }
    }
}
