namespace Leonov.BugTracker.Controllers
{
    using Leonov.BugTracker.Domain.Interfaces;

    using Microsoft.AspNetCore.Mvc;

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
        public JsonResult GetUserTypes([FromServices] IUserTypeService userTypeService)
        {
            var result = new JsonResult(userTypeService.GetAll());
            return result;
        }
    }
}
