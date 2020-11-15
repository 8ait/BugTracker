namespace Leonov.BugTracker.Domain.Interfaces
{
    using Leonov.BugTracker.Domain.Models;

    /// <summary>
    /// Сервис для аутентификации.
    /// </summary>
    public interface IAuthoriseService
    {
        /// <summary>
        /// Войти.
        /// </summary>
        /// <param name="signIn"> Данные для входа. </param>
        public void SignIn(SignIn signIn);

        /// <summary>
        /// Зарегистрироваться.
        /// </summary>
        /// <param name="signUp"> Данные для регистрации. </param>
        public void SignUp(SignUp signUp);

        /// <summary>
        /// Проверка на вход.
        /// </summary>
        /// <returns></returns>
        public bool IsAuthorized();
    }
}
