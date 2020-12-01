namespace Leonov.BugTracker.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Leonov.BugTracker.Authenticate;
    using Leonov.BugTracker.Domain.Interfaces;
    using Leonov.BugTracker.Dto;
    using Leonov.BugTracker.Services.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    public class AuditController : Controller
    {
        private readonly IAuditService _auditService;
        private readonly IAuditMappingService _auditMappingService;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="auditMappingService"> Сервис для маппинга аудитов. </param>
        /// <param name="auditService"> Сервис для аудитов. </param>
        public AuditController(IAuditMappingService auditMappingService, IAuditService auditService)
        {
            _auditMappingService = auditMappingService;
            _auditService = auditService;
        }

        [Auth(Arm.Default)]
        public IActionResult Index()
        {
            return View("AuditList");
        }

        /// <summary>
        /// Получить таблицу из проектов пользователя.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="count"> Количество элементов на странице. </param>
        /// <returns> Список проектов. </returns>
        [Auth(Arm.Default)]
        public async Task<JsonResult> GetUserAuditTable(int page, int count)
        {
            var errors = new List<string>();

            if (page <= 0)
                errors.Add("Неверный формат страницы.");

            if (count <= 0)
                errors.Add("Неверный формат количества элементов на странице.");

            if (errors.Any())
            {
                return new JsonResult(new Result(errors));
            }

            var table = await _auditService.GetUserAuditTableInfoAsync(page, count, errors);
            var tableDto = table != null ? _auditMappingService.TableInfoToTableInfoDto(table) : null;

            if (errors.Any())
            {
                return new JsonResult(new Result(errors));
            }

            return new JsonResult(new Result<TableInfoDto<AuditInfoDto>>(tableDto, errors));
        }

        /// <summary>
        /// Получить таблицу из проектов пользователя.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="count"> Количество элементов на странице. </param>
        /// <returns> Список проектов. </returns>
        [Auth(Arm.Default)]
        public async Task<JsonResult> GetAuditAllTable(int page, int count)
        {
            var errors = new List<string>();

            if (page <= 0)
                errors.Add("Неверный формат страницы.");

            if (count <= 0)
                errors.Add("Неверный формат количества элементов на странице.");

            if (errors.Any())
            {
                return new JsonResult(new Result(errors));
            }

            var table = await _auditService.GetAuditAllTableInfoAsync(page, count, errors);
            var tableDto = table != null ? _auditMappingService.TableInfoToTableFullInfoDto(table) : null;

            if (errors.Any())
            {
                return new JsonResult(new Result(errors));
            }

            return new JsonResult(new Result<TableInfoDto<AuditFullInfoDto>>(tableDto, errors));
        }
    }
}
