namespace Leonov.BugTracker.Domain.Models
{
    using System.Collections.Generic;

    using Leonov.BugTracker.Domain.Models.Base;

    /// <summary>
    /// Тип пользователя.
    /// </summary>
    public class UserType: BaseDictionaryEntity
    {
        /// <summary>
        /// Доступные права.
        /// </summary>
        public List<Arm> Arms { get; set; }
    }
}
