namespace Leonov.BugTracker.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Leonov.BugTracker.Domain.Interfaces;
    using Leonov.BugTracker.Domain.Models;
    using Leonov.BugTracker.Models;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Контроллер для аутентификации.
    /// </summary>
    public class AuthController : Controller
    {
        private readonly IAuthoriseService _authoriseService;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public AuthController(IAuthoriseService authoriseService)
        {
            _authoriseService = authoriseService;
        }

        /// <summary>
        /// Начальная страница.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View("Login");
        }

        /// <summary>
        /// Войти в систему.
        /// </summary>
        /// <param name="signInDto"> Данные для входа. </param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(SignInDto signInDto)
        {
            if (ModelState.IsValid)
            {
                _authoriseService.SignIn(new SignIn()
                {
                    Login = signInDto.Login,
                    Password = signInDto.Password
                });
                return RedirectToAction("Index", "Home");
            }

            return View("Login", signInDto);
        }

        public IActionResult SignIp()
        {
            return null;
        }
    }
}
