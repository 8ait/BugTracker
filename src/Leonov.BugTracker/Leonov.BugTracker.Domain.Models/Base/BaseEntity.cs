namespace Leonov.BugTracker.Domain.Models.Base
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
