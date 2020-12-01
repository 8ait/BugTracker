namespace Leonov.BugTracker.Dto
{
    /// <summary>
    /// Информация о комментариях пользователей.
    /// </summary>
    public class UserCommentaryInfoDto
    {
        /// <summary>
        /// Количество комментареив.
        /// </summary>
        public int CommentaryCount { get; set; }

        /// <summary>
        /// Популярность комментареив.
        /// </summary>
        public int Popularity { get; set; }
    }
}
