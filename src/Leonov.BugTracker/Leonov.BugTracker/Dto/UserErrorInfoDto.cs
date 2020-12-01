namespace Leonov.BugTracker.Dto
{
    /// <summary>
    /// Дто информации об ошибках пользователя.
    /// </summary>
    public class UserErrorInfoDto
    {
        /// <summary>
        /// Количество активных задач.
        /// </summary>
        public int ActiveCount { get; set; }

        /// <summary>
        /// Количество неактивных задач.
        /// </summary>
        public int NonActiveCount { get; set; }
    }
}
