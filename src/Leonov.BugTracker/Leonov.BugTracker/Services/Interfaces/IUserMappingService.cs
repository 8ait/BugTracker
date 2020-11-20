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
        /// Пользователя в пользователя дто.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        /// <returns> Дто пользователя. </returns>
        public UserDto UserInUserDto(User user);

        /// <summary>
        /// Дто пользователя в информацию пользователя.
        /// </summary>
        /// <param name="userDto"> Дто ползователя. </param>
        /// <returns> Информация пользователя. </returns>
        public UserInfo UserDtoInUserInfo(UserDto userDto);

        /// <summary>
        /// Дто обновления пароля в сущность обновления пароля.
        /// </summary>
        /// <param name="userPasswordUpdateDto"> Дто обновления пароля. </param>
        /// <returns> Сущность обновления пароля. </returns>
        public UserPasswordUpdate
            UserPasswordUpdateDtoInuserPasswordUpdate(UserPasswordUpdateDto userPasswordUpdateDto);
    }
}
