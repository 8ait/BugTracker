namespace Leonov.BugTracker.Domain.Models
{
    using System;

    /// <summary>
    /// Базовая сущность БД.
    /// </summary>
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
