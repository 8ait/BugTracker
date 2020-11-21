namespace Leonov.BugTracker.Dto
{
    using System;

    /// <summary>
    /// Дто информации о проекте в таблице.
    /// </summary>
    public class ProjectInfoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
