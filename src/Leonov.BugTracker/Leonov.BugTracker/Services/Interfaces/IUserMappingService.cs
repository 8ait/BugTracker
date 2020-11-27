namespace Leonov.BugTracker.Services.Interfaces
{
    using Leonov.BugTracker.Domain.Models;
    using Leonov.BugTracker.Domain.Models.Table;
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

        /// <summary>
        /// Маппинг таблицы пользователей в таблицу с информацией пользователей.
        /// </summary>
        /// <param name="tableInfo"> Таблица пользователей. </param>
        /// <returns> Таблица с информацией. </returns>
        public TableInfoDto<UserInfoDto> TableInfoToTableInfoDto(TableInfo<User> tableInfo);

        /// <summary>
        /// Маппинг таблицы пользователей в проекте в таблицу с дто.
        /// </summary>
        /// <param name="tableInfo"> Таблица пользователей. </param>
        /// <returns> Таблица с информацией. </returns>
        public TableInfoDto<UserInProjectDto> TableInfoToTableInfoDtoUserInProject(TableInfo<UserInProject> tableInfo);
    }
}
