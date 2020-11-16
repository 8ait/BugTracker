namespace Leonov.BugTracker.Domain.Models
{
    /// <summary>
    /// Тип пользователя.
    /// </summary>
    public class UserType: BaseEntity
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return Name;
        }
    }
}
