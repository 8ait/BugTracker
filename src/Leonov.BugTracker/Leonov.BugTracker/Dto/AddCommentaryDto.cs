namespace Leonov.BugTracker.Dto
{
    using System;

    /// <summary>
    /// Дто создания комментария.
    /// </summary>
    public class AddCommentaryDto
    {
        /// <summary>
        /// Идентификатор ошибки.
        /// </summary>
        public Guid ErrorId { get; set; }

        /// <summary>
        /// Родительский комментарий.
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// Значение комментария.
        /// </summary>
        public string Value { get; set; }
    }
}
