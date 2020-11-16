namespace Leonov.BugTracker.Services.Interfaces
{
    using System.Threading.Tasks;

    using Leonov.BugTracker.Domain.Models.Identity;
    using Leonov.BugTracker.Models;

    /// <summary>
    /// Сервис для маппинга сущностей авторизации.
    /// </summary>
    public interface IAuthoriseMappingService
    {
        /// <summary>
        /// Дто авторизации в авторизацию.
        /// </summary>
        /// <param name="signInDto"> Дто авторизации. </param>
        /// <returns> Авторизация. </returns>
        SignIn SignInDtoToSignIn(SignInDto signInDto);

        /// <summary>
        /// Дто регистрации в регистрацию.
        /// </summary>
        /// <param name="signUpDto"> Дто регистрации. </param>
        /// <returns> Регистрация </returns>
        Task<SignUp> SignUpDtoToSignUpAsync(SignUpDto signUpDto);
    }
}
