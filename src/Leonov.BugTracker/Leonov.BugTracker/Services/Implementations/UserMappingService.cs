namespace Leonov.BugTracker.Services.Implementations
{
    using Leonov.BugTracker.Domain.Models;
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
    }
}
