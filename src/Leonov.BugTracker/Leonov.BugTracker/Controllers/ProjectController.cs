namespace Leonov.BugTracker.Controllers
{
    using System;
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
        /// Начальное создание проекта.
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateIndex()
        {
            var errors = new List<string>();
            ViewData["errors"] = errors;
            return View("CreateProject");
        }

        /// <summary>
        /// Создать проект.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create(CreateProjectDto createProjectDto)
        {
            var errors = new List<string>();
            ViewData["errors"] = errors;
            if (ModelState.IsValid)
            {
                var project = _projectMappingService.CreateProjectDtoToProject(createProjectDto);
                await _projectService.CreateAsync(project, errors);
                if (errors.Any())
                {
                    return Error();
                }
                return RedirectToAction("Index", "Project");
            }

            return Error();

            IActionResult Error()
            {
                return View("CreateProject", createProjectDto);
            }
        }

        /// <summary>
        /// Индекс редактирования.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> EditIndex(Guid id)
        {
            var project = await _projectService.GetAsync(id);
            if (project is null)
            {
                return NotFound();
            }
            var editProjectDto = _projectMappingService.ProjectToEditProjectDto(project);
            var errors = new List<string>();
            ViewData["errors"] = errors;

            return View("EditProject", editProjectDto);
        }

        /// <summary>
        /// Редактировать проект.
        /// </summary>
        /// <param name="editProjectDto"> Дто редактирования </param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(EditProjectDto editProjectDto)
        {
            var errors = new List<string>();
            ViewData["errors"] = errors;
            if (ModelState.IsValid)
            {
                var project = _projectMappingService.EditProjectDtoToProject(editProjectDto);
                await _projectService.EditAsync(project, errors);
                if (errors.Any())
                {
                    return Error();
                }
                return RedirectToAction("Index", "Project");
            }

            return Error();

            IActionResult Error()
            {
                return View("EditProject", editProjectDto);
            }
        }

        /// <summary>
        /// Получить страницу проекта.
        /// </summary>
        /// <param name="id"> Id проекта. </param>
        /// <returns></returns>
        public async Task<IActionResult> GetProject(Guid id)
        {
            var project = await _projectService.GetAsync(id);
            if (project is null)
            {
                return NotFound();
            }

            var projectDto = _projectMappingService.ProjectToProjectDto(project);

            return View("ProjectDetail", projectDto);
        }

        /// <summary>
        /// Удалить проект.
        /// </summary>
        /// <param name="id"> Идентфиикатор проекта. </param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<JsonResult> Delete([FromBody] Guid id)
        {
            var errors = new List<string>();
            await _projectService.DeleteAsync(id, errors);
            return new JsonResult(new Result(errors));
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

        /// <summary>
        /// Получить таблицу из проектов пользователя.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="count"> Количество элементов на странице. </param>
        /// <param name="id"> ID пользователя. </param>
        /// <returns> Список проектов. </returns>
        public async Task<JsonResult> GetUserProjectTableById(int page, int count, Guid? id)
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

            var table = await _projectService.GetUserProjectTableInfoAsync(page, count, errors, id);
            var tableDto = table != null ? _projectMappingService.TableInfoToTableInfoDto(table) : null;

            if (errors.Any())
            {
                return new JsonResult(new Result(errors));
            }

            return new JsonResult(new Result<TableInfoDto<ProjectInfoDto>>(tableDto, errors));
        }

        /// <summary>
        /// Получить всю таблицу проектов.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="count"> Кол-во элементов на странице. </param>
        /// <returns></returns>
        public async Task<JsonResult> GetProjectAllTable(int page, int count)
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

            var table = await _projectService.GetProjectAllTableInfoAsync(page, count, errors);
            var tableDto = table != null ? _projectMappingService.TableInfoToTableInfoDto(table) : null;

            if (errors.Any())
            {
                return new JsonResult(new Result(errors));
            }

            return new JsonResult(new Result<TableInfoDto<ProjectInfoDto>>(tableDto, errors));
        }
    }
}
