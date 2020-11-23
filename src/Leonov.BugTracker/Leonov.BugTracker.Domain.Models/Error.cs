namespace Leonov.BugTracker.Domain.Models
{
    using System;

    using Leonov.BugTracker.Domain.Models.Base;

    /// <summary>
    /// Заведенная ошибка.
    /// </summary>
    public class Error: BaseEntity
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Область возникновения.
        /// </summary>
        public OriginArea OriginArea { get; set; }

        /// <summary>
        /// Ид области возникновения.
        /// </summary>
        public int OriginId { get; set; }

        /// <summary>
        /// Статус ошибки.
        /// </summary>
        public ErrorStatus ErrorStatus { get; set; }

        /// <summary>
        /// Ид статуса.
        /// </summary>
        public int ErrorStatusId { get; set; }

        /// <summary>
        /// Создатель ошибки.
        /// </summary>
        public UserInProject CreateUser { get; set; }

        /// <summary>
        /// Ид создателя.
        /// </summary>
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// Ответственный за выполнение ошибки.
        /// </summary>
        public UserInProject ResponsibleUser { get; set; }

        /// <summary>
        /// Ид ответсвенного.
        /// </summary>
        public Guid ResponsibleUserId { get; set; }
    }
}
