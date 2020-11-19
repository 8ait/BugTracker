namespace Leonov.BugTracker.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Leonov.BugTracker.Domain.Interfaces;
    using Leonov.BugTracker.Dto;
    using Leonov.BugTracker.Services.Interfaces;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    /// <summary>
    /// Контроллер для аутентификации.
    /// </summary>
    public class AuthController : Controller
    {
        private readonly IAuthoriseService _authoriseService;
        private readonly IAuthoriseMappingService _authoriseMappingService;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public AuthController(IAuthoriseService authoriseService, IAuthoriseMappingService authoriseMappingService)
        {
            _authoriseService = authoriseService;
            _authoriseMappingService = authoriseMappingService;
        }

        /// <summary>
        /// Начальная страница.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var errors = new List<string>();
            ViewData["errors"] = errors;
            return View("Login");
        }

        /// <summary>
        /// начальная страница для регистрации.
        /// </summary>
        /// <param name="userTypeService"> Сервис для типов пользователя. </param>
        /// <returns> Начальная страница. </returns>
        public IActionResult RegisterIndex([FromServices] IUserTypeService userTypeService)
        {
            var errors = new List<string>();
            ViewData["errors"] = errors;
            ViewBag.UserTypes = new SelectList(userTypeService.GetAll(), "Id", "Name");
            return View("Register");
        }

        /// <summary>
        /// Выйти их системы.
        /// </summary>
        /// <returns></returns>
        public IActionResult SignOut()
        {
            _authoriseService.SignOut();
            var errors = new List<string>();
            ViewData["errors"] = errors;
            return View("Login");
        }

        /// <summary>
        /// Войти в систему.
        /// </summary>
        /// <param name="signInDto"> Данные для входа. </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(SignInDto signInDto)
        {
            var errors = new List<string>();
            ViewData["errors"] = errors;
            if (ModelState.IsValid)
            {
                var signIn = _authoriseMappingService.SignInDtoToSignIn(signInDto);
                await _authoriseService.SignInAsync(signIn, errors);
                if (errors.Any())
                {
                    return Error();
                }
                return RedirectToAction("Index", "Home");
            }

            return Error();

            IActionResult Error()
            {
                return View("Login", signInDto);
            }
        }

        /// <summary>
        /// Зарегистрироваться в системе.
        /// </summary>
        /// <param name="signUpDto"> Данные для регистрации. </param>
        /// <param name="userTypeService"> Сервис для типов пользователей. </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto, [FromServices] IUserTypeService userTypeService)
        {
            ViewBag.UserTypes = new SelectList(userTypeService.GetAll(), "Id", "Name");
            var errors = new List<string>();
            ViewData["errors"] = errors;
            if (ModelState.IsValid)
            {
                var signUp = await _authoriseMappingService.SignUpDtoToSignUpAsync(signUpDto);
                await _authoriseService.SignUpAsync(signUp, errors);
                if (errors.Any())
                {
                    return Error();
                }
                return RedirectToAction("Index", "Home");
            }

            return Error();

            IActionResult Error()
            {
                return View("Register", signUpDto);
            }
        }
    }
}
