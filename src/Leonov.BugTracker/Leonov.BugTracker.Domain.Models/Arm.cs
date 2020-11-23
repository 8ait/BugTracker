namespace Leonov.BugTracker.Domain.Models
{
    using Leonov.BugTracker.Domain.Models.Base;
    using System.Collections.Generic;

    /// <summary>
    /// Право пользователя.
    /// </summary>
    public class Arm: BaseDictionaryEntity
    {
        /// <summary>
        /// Типы ползьователей.
        /// </summary>
        public List<UserType> UserTypes { get; set; }
    }
}
