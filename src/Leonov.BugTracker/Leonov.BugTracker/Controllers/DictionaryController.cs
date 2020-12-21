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

        /// <summary>
        /// Получить все статусы ошибок.
        /// </summary>
        /// <param name="errorService"></param>
        /// <returns></returns>
        [HttpGet]
        [Auth(Arm.Default)]
        public JsonResult GetErrorStatuses([FromServices] IErrorStatusService errorStatusService)
        {
            var errors = new List<string>();
            var errorStatuses = errorStatusService.GetAll();
            return new JsonResult(new Result<List<ErrorStatus>>(errorStatuses, errors));
        }

        /// <summary>
        /// Получить все области возникновения ошибок.
        /// </summary>
        /// <param name="errorService"></param>
        /// <returns></returns>
        [HttpGet]
        [Auth(Arm.Default)]
        public JsonResult GetErrorOrigins([FromServices] IOriginAreaService originAreaService)
        {
            var errors = new List<string>();
            var originAreas = originAreaService.GetAll();
            return new JsonResult(new Result<List<OriginArea>>(originAreas, errors));
        }
    }
}
