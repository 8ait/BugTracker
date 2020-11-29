namespace Leonov.BugTracker.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Дто изменения ошибки.
    /// </summary>
    public class EditErrorDto
    {
        /// <summary>
        /// Идентфиикаторю
        /// </summary>
        [Required(ErrorMessage = "Отсутсвует идентификатор.")]
        public Guid Id { get; set; }

        /// <summary>
        /// Название ошибки.
        /// </summary>
        [Required(ErrorMessage = "У ошибки должно быть имя.")]
        public string Name { get; set; }

        /// <summary>
        /// Описание ошибки.
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// Дата создания ошибки.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Область возникновения ошибки.
        /// </summary>
        [Required(ErrorMessage = "У ошибки должна быть область возникновения.")]
        public int OriginAreaId { get; set; }

        /// <summary>
        /// Статус ошибки.
        /// </summary>
        [Required(ErrorMessage = "У ошибки должен быть статус ошибки.")]
        public int ErrorStatusId { get; set; }

        /// <summary>
        /// Идентификатор создателя ошибки.
        /// </summary>
        [Required(ErrorMessage = "У ошибки должен быть создатель.")]
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// Имя создателя.
        /// </summary>
        public string CreateUserName { get; set; }

        /// <summary>
        /// Идентификатор проекта.
        /// </summary>
        [Required(ErrorMessage = "Идентификатор проекта не может быть пустым.")]
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Название проекта.
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Идентификатор ответсвенного.
        /// </summary>
        [Required(ErrorMessage = "Необходимо назначить ответственного.")]
        public Guid ResponsibleUserId { get; set; }
    }
}
