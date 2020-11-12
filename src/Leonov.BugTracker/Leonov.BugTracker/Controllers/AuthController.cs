namespace Leonov.BugTracker.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Контроллер для аутентификации.
    /// </summary>
    public class AuthController : Controller
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public AuthController()
        {

        }

        public IActionResult Index()
        {
            return View("Login");
        }
    }
}
