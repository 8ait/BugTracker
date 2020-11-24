namespace Leonov.BugTracker.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Дто для редактирования проекта.
    /// </summary>
    public class EditProjectDto
    {
        /// <summary>
        /// Идентфиикатор.
        /// </summary>
        [Required(ErrorMessage = "Отсутвует идентификатор проекта.")]
        public Guid Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        [Required(ErrorMessage = "Название является обязательным атрибутом.")]
        public string Name { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string About { get; set; }
    }
}
