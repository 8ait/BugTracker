namespace Leonov.BugTracker.Domain.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Leonov.BugTracker.Domain.Models.Identity;

    /// <summary>
    /// Сервис для аутентификации.
    /// </summary>
    public interface IAuthoriseService
    {
        /// <summary>
        /// Войти.
        /// </summary>
        /// <param name="signIn"> Данные для входа. </param>
        public Task SignInAsync(SignIn signIn, List<string> errors);

        /// <summary>
        /// Зарегистрироваться.
        /// </summary>
        /// <param name="signUp"> Данные для регистрации. </param>
        public Task SignUpAsync(SignUp signUp, List<string> errors);

        /// <summary>
        /// Выйти из системы.
        /// </summary>
        public void SignOut();

        /// <summary>
        /// Проверка на вход.
        /// </summary>
        /// <returns></returns>
        public bool IsAuthorized();
    }
}
