namespace Leonov.BugTracker.Authenticate
{
    using Leonov.BugTracker.Domain.Interfaces;
    using Leonov.BugTracker.Domain.Models;

    using Microsoft.AspNetCore.Http;

    /// <inheritdoc />
    public class AuthoriseService: IAuthoriseService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public AuthoriseService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <inheritdoc />
        public void SignIn(SignIn signIn)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Append("auth", "admin");
        }

        /// <inheritdoc />
        public void SignUp(SignUp signUp)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public bool IsAuthorized()
        {
            var cookie = _httpContextAccessor.HttpContext.Request.Cookies["auth"];
            return cookie == "admin";
        }
    }
}
