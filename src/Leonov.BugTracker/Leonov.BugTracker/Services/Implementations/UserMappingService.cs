namespace Leonov.BugTracker.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;

    using Leonov.BugTracker.Domain.Models;
    using Leonov.BugTracker.Domain.Models.Table;
    using Leonov.BugTracker.Dto;
    using Leonov.BugTracker.Services.Interfaces;

    /// <inheritdoc />
    public class UserMappingService : IUserMappingService
    {
        /// <inheritdoc />
        public UserDto UserInUserDto(User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                Firstname = user.FirstName,
                Surname = user.Surname,
                UserTypeName = user.UserType.Name,
                UserTypeId = user.UserType.Id
            };
        }

        /// <inheritdoc />
        public UserInfo UserDtoInUserInfo(UserDto userDto)
        {
            return new UserInfo()
            {
                Id = userDto.Id,
                Firstname = userDto.Firstname,
                Surname = userDto.Surname,
                UserType = new UserType()
                {
                    Id = userDto.UserTypeId
                }
            };
        }

        /// <inheritdoc />
        public UserPasswordUpdate UserPasswordUpdateDtoInuserPasswordUpdate(UserPasswordUpdateDto userPasswordUpdateDto)
        {
            return new UserPasswordUpdate()
            {
                Id = userPasswordUpdateDto.Id,
                NewPassword = userPasswordUpdateDto.NewPassword,
                OldPassword = userPasswordUpdateDto.OldPassword
            };
        }

        /// <inheritdoc />
        public TableInfoDto<UserInfoDto> TableInfoToTableInfoDto(TableInfo<User> tableInfo)
        {
            return new TableInfoDto<UserInfoDto>()
            {
                Count = tableInfo.Count,
                CountOfPages = tableInfo.CountOfPages,
                Page = tableInfo.Page,
                RowDtos = UserToUserInfoDto(tableInfo.Rows).ToList()
            };
        }

        /// <inheritdoc />
        public TableInfoDto<UserInProjectDto> TableInfoToTableInfoDtoUserInProject(TableInfo<UserInProject> tableInfo)
        {
            return new TableInfoDto<UserInProjectDto>()
            {
                Count = tableInfo.Count,
                CountOfPages = tableInfo.CountOfPages,
                Page = tableInfo.Page,
                RowDtos = UserInProjectToUserInProjectDto(tableInfo.Rows).ToList()
            };
        }

        /// <summary>
        /// Маппинг пользователя в дто информации для пользователя.
        /// </summary>
        /// <param name="items"> Пользователи. </param>
        /// <returns> Дто информации для пользователя. </returns>
        private IEnumerable<UserInProjectDto> UserInProjectToUserInProjectDto(List<UserInProject> items)
        {
            foreach (var item in items)
            {
                yield return new UserInProjectDto()
                {
                    Id = item.Id,
                    Firstname = item.User.FirstName,
                    Surname = item.User.Surname,
                    StartDate = item.StartDate.ToShortDateString(),
                    UserId = item.UserId
                };
            }
        }

        /// <summary>
        /// Маппинг пользователя в дто информации для пользователя.
        /// </summary>
        /// <param name="items"> Пользователи. </param>
        /// <returns> Дто информации для пользователя. </returns>
        private IEnumerable<UserInfoDto> UserToUserInfoDto(List<User> items)
        {
            foreach (var item in items)
            {
                yield return new UserInfoDto()
                {
                    Id = item.Id,
                    Firstname = item.FirstName,
                    Surname = item.Surname,
                    UserTypeName = item.UserType.Name
                };
            }
        }
    }
}
