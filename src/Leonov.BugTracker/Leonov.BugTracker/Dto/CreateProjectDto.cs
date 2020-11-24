namespace Leonov.BugTracker.Dto
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Дто создания проекта.
    /// </summary>
    public class CreateProjectDto
    {
        /// <summary>
        /// Название.
        /// </summary>
        [Required(ErrorMessage = "Название проекта не может быть пустым.")]
        public string Name { get; set; }

        /// <summary>
        /// Опписание.
        /// </summary>
        public string About { get; set; }
    }
}
