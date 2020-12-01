namespace Leonov.BugTracker.Controllers
{
    using System.Collections.Generic;

    using Leonov.BugTracker.Authenticate;
    using Leonov.BugTracker.Domain.Interfaces;
    using Leonov.BugTracker.Domain.Models;

    using Microsoft.AspNetCore.Mvc;

    using Arm = Leonov.BugTracker.Authenticate.Arm;

    /// <summary>
    /// Контроллер для получения значения словарей.
    /// </summary>
    public class DictionaryController : Controller
    {
        /// <summary>
        /// Получить типы пользователей.
        /// </summary>
        /// <returns> Список типов пользователей. </returns>
        [HttpGet]
        [Auth(Arm.Default)]
        public JsonResult GetUserTypes([FromServices] IUserTypeService userTypeService)
        {
            var errors = new List<string>();
            var result = userTypeService.GetAll();
            return new JsonResult(new Result<List<UserType>>(result, errors));
        }
    }
}
