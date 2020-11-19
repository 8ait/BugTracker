namespace Leonov.BugTracker.Services.Interfaces
{
    using Leonov.BugTracker.Domain.Models;
    using Leonov.BugTracker.Dto;

    /// <summary>
    /// Сервис для маппинга пользователя.
    /// </summary>
    public interface IUserMappingService
    {
        /// <summary>
        /// ПОльзователя в пользователя дто.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        /// <returns> Дто пользователя. </returns>
        public UserDto UserInUserDto(User user);
    }
}
