namespace Leonov.BugTracker.Services.Implementations
{
    using System.Threading.Tasks;

    using Leonov.BugTracker.Domain.Interfaces;
    using Leonov.BugTracker.Domain.Models.Identity;
    using Leonov.BugTracker.Dto;
    using Leonov.BugTracker.Services.Interfaces;

    /// <inheritdoc />
    public class AuthoriseMappingService : IAuthoriseMappingService
    {
        private readonly IUserTypeService _userTypeService;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="userTypeService"> Сервис типов пользователей. </param>
        public AuthoriseMappingService(IUserTypeService userTypeService)
        {
            _userTypeService = userTypeService;
        }

        /// <inheritdoc />
        public SignIn SignInDtoToSignIn(SignInDto signInDto)
        {
            return new SignIn()
            {
                Login = signInDto.Login,
                Password = signInDto.Password
            };
        }

        /// <inheritdoc />
        public async Task<SignUp> SignUpDtoToSignUpAsync(SignUpDto signUpDto)
        {
            var userType = await _userTypeService.GetByIdAsync(signUpDto.UserTypeId);
            return new SignUp()
            {
                Login = signUpDto.Login,
                Password = signUpDto.Password,
                Surname = signUpDto.Surname,
                FirstName = signUpDto.Firstname,
                UserType = userType
            };
        }
    }
}
