namespace Leonov.BugTracker.Dto
{
    using System;

    /// <summary>
    /// Дто изменения статуса ошибки.
    /// </summary>
    public class ChangeStatusErrorDto
    {
        /// <summary>
        /// Идентификатор ошибки.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Статус ошибки.
        /// </summary>
        public int ErrorStatusId { get; set; }
    }
}
