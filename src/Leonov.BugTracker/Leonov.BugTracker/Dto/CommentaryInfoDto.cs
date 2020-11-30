namespace Leonov.BugTracker.Dto
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Дто информации о комментарии.
    /// </summary>
    public class CommentaryInfoDto
    {
        /// <summary>
        /// Идентификатор комментария.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя автора.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public string CreateDateTime { get; set; }

        /// <summary>
        /// Значение.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Значение имени пользвоателя.
        /// </summary>
        public string ParentUsername { get; set; }

        /// <summary>
        /// Дочерние комментарии.
        /// </summary>
        public List<CommentaryInfoDto> Childrens { get; set; }
    }
}
