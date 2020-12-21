namespace Leonov.BugTracker.Dto
{
    using System;

    /// <summary>
    /// Дто для изменения активности аккаунта.
    /// </summary>
    public class ChangeAccountStatusDto
    {
        /// <summary>
        /// Идентифкатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Активность.
        /// </summary>
        public bool Active { get; set; }
    }
}
