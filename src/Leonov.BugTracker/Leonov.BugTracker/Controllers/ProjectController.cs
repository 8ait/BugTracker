namespace Leonov.BugTracker.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Leonov.BugTracker.Domain.Interfaces;
    using Leonov.BugTracker.Dto;
    using Leonov.BugTracker.Services.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Контроллер для работы с проектами.
    /// </summary>
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IProjectMappingService _projectMappingService;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="projectService"> Сервис для работы с проектами. </param>
        public ProjectController(IProjectService projectService, IProjectMappingService projectMappingService)
        {
            _projectService = projectService;
            _projectMappingService = projectMappingService;
        }

        /// <summary>
        /// Вернуть главную страницу.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View("ProjectList");
        }

        /// <summary>
        /// Получить таблицу из проектов пользователя.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="count"> Количество элементов на странице. </param>
        /// <returns> Список проектов. </returns>
        public async Task<JsonResult> GetUserProjectTable(int page, int count)
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

            var table = await _projectService.GetUserProjectTableInfoAsync(page, count, errors);
            var tableDto = table != null ? _projectMappingService.TableInfoToTableInfoDto(table) : null;

            if (errors.Any())
            {
                return new JsonResult(new Result(errors));
            }

            return new JsonResult(new Result<TableInfoDto<ProjectInfoDto>>(tableDto, errors));
        }
    }
}
