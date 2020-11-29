namespace Leonov.BugTracker.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Leonov.BugTracker.Domain.Interfaces;
    using Leonov.BugTracker.Domain.Models;
    using Leonov.BugTracker.Dto;
    using Leonov.BugTracker.Services.Interfaces;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Контроллер для ошибок.
    /// </summary>
    public class ErrorController : Controller
    {
        private readonly IErrorService _errorService;
        private readonly IProjectService _projectService;
        private readonly IAuthoriseService _authoriseService;
        private readonly IUserService _userService;
        private readonly IErrorMappingService _errorMappingService;
        private readonly IErrorStatusService _errorStatusService;
        private readonly IOriginAreaService _originAreaService;

        /// <summary>
        /// Контроллер.
        /// </summary>
        /// <param name="errorService">  </param>
        /// <param name="errorMappingService"></param>
        public ErrorController(IErrorService errorService,
            IErrorMappingService errorMappingService,
            IAuthoriseService authoriseService,
            IProjectService projectService,
            IErrorStatusService errorStatusService,
            IOriginAreaService originAreaService,
            IUserService userService)
        {
            _errorService = errorService;
            _errorMappingService = errorMappingService;
            _authoriseService = authoriseService;
            _projectService = projectService;
            _errorStatusService = errorStatusService;
            _originAreaService = originAreaService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View("ErrorList");
        }

        /// <summary>
        /// Получить ошибку.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetError(Guid id)
        {
            var error = await _errorService.GetAsync(id);

            var errorDto = _errorMappingService.ErrorToErrorDto(error);

            return View("ErrorDetail", errorDto);
        }

        /// <summary>
        /// Начальная страница создания ошибки.
        /// </summary>
        /// <param name="projectId"> Идентификатор проекта для создания. </param>
        /// <returns></returns>
        public async Task<IActionResult> CreateIndex(Guid projectId)
        {
            var errors = new List<string>();
            ViewData["errors"] = errors;
            ViewBag.ErrorStatuses = new SelectList(_errorStatusService.GetAll(), "Id", "Name");
            ViewBag.OriginAreas = new SelectList(_originAreaService.GetAll(), "Id", "Name");
            ViewBag.ProjectUsers = new SelectList((await _userService.GetUsersByProject(projectId)).Select(x => new {Id = x.Id, Name = $"{x.User.FirstName} {x.User.Surname}"}), "Id", "Name");

            var project = await _projectService.GetAsync(projectId);
            if (project is null)
            {
                return NotFound();
            }

            var user = await _authoriseService.GetCurrentUser();
            if (user is null)
            {
                return NotFound();
            }

            var userInProject = await _userService.GetUserInProjectByUserIdAndProjectId(user.Id, projectId);
            if (userInProject is null)
            {
                return NotFound();
            }

            var createErrorDto = new CreateErrorDto()
            {
                CreateUserId = userInProject.Id,
                CreateUserName = $"{user.FirstName} {user.Surname}",
                ProjectId = project.Id,
                ProjectName = project.Name
            };
            return View("CreateError", createErrorDto);
        }

        /// <summary>
        /// Создать ошибку.
        /// </summary>
        /// <param name="createErrorDto"></param>
        /// <returns></returns>
        public async Task<IActionResult> Create(CreateErrorDto createErrorDto)
        {
            var errors = new List<string>();
            ViewData["errors"] = errors;

            ViewBag.ErrorStatuses = new SelectList(_errorStatusService.GetAll(), "Id", "Name");
            ViewBag.OriginAreas = new SelectList(_originAreaService.GetAll(), "Id", "Name");
            ViewBag.ProjectUsers = new SelectList((await _userService.GetUsersByProject(createErrorDto.ProjectId)).Select(x => new { Id = x.Id, Name = $"{x.User.FirstName} {x.User.Surname}" }), "Id", "Name");

            var project = await _projectService.GetAsync(createErrorDto.ProjectId);
            if (project is null)
            {
                return NotFound();
            }

            var user = await _authoriseService.GetCurrentUser();
            if (user is null)
            {
                return NotFound();
            }

            var userInProject = await _userService.GetUserInProjectByUserIdAndProjectId(user.Id, createErrorDto.ProjectId);
            if (userInProject is null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var error = _errorMappingService.CreateErrorDtoToError(createErrorDto);
                await _errorService.CreateAsync(error, errors);
                if (errors.Any())
                {
                    return Error();
                }

                return RedirectToAction("Index", "Error");
            }

            return Error();

            IActionResult Error()
            {
                return View("CreateError", createErrorDto);
            }
        }

        /// <summary>
        /// Начальная страница редактирования.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> EditIndex(Guid id)
        {
            var errors = new List<string>();
            ViewData["errors"] = errors;

            var error = await _errorService.GetAsync(id);
            var editErrorDto = _errorMappingService.ErrorToEditErrorDto(error);

            if (error is null)
            {
                return NotFound();
            }

            ViewBag.ErrorStatuses = new SelectList(_errorStatusService.GetAll(), "Id", "Name");
            ViewBag.OriginAreas = new SelectList(_originAreaService.GetAll(), "Id", "Name");
            ViewBag.ProjectUsers = new SelectList((await _userService.GetUsersByProject(error.CreateUser.ProjectId)).Select(x => new { Id = x.Id, Name = $"{x.User.FirstName} {x.User.Surname}" }), "Id", "Name");

            return View("EditError", editErrorDto);
        }

        /// <summary>
        /// Начальная страница редактирования.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(EditErrorDto editErrorDto)
        {
            var errors = new List<string>();

            if (ModelState.IsValid)
            {
                var error = _errorMappingService.EditErrorDtoToError(editErrorDto);
                await _errorService.EditAsync(error, errors);
                if (errors.Any())
                {
                    return await Error();
                }

                return RedirectToAction("Index", "Error");
            }

            return await Error();

            async Task<IActionResult> Error()
            {
                ViewData["errors"] = errors;
                ViewBag.ErrorStatuses = new SelectList(_errorStatusService.GetAll(), "Id", "Name");
                ViewBag.OriginAreas = new SelectList(_originAreaService.GetAll(), "Id", "Name");
                ViewBag.ProjectUsers = new SelectList((await _userService.GetUsersByProject(editErrorDto.ProjectId)).Select(x => new { Id = x.Id, Name = $"{x.User.FirstName} {x.User.Surname}" }), "Id", "Name");
                return View("EditError", editErrorDto);
            }
        }

        /// <summary>
        /// Получить таблицу из ошибок пользователя.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="count"> Количество элементов на странице. </param>
        /// <returns> Таблица ошибок. </returns>
        public async Task<JsonResult> GetUserErrorTable(int page, int count)
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

            var table = await _errorService.GetUserErrorTableInfoAsync(page, count, errors);
            var tableDto = table != null ? _errorMappingService.TableInfoToTableInfoDto(table) : null;

            if (errors.Any())
            {
                return new JsonResult(new Result(errors));
            }

            return new JsonResult(new Result<TableInfoDto<ErrorInfoDto>>(tableDto, errors));
        }

        /// <summary>
        /// Получить таблицу из ошибок проекта.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="count"> Количество элементов на странице. </param>
        /// <returns> Таблица ошибок. </returns>
        public async Task<JsonResult> GetProjectErrorTable(int page, int count, Guid id)
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

            var table = await _errorService.GetProjectErrorTableInfoAsync(page, count, id, errors);
            var tableDto = table != null ? _errorMappingService.TableInfoToTableInfoDto(table) : null;

            if (errors.Any())
            {
                return new JsonResult(new Result(errors));
            }

            return new JsonResult(new Result<TableInfoDto<ErrorInfoDto>>(tableDto, errors));
        }

        /// <summary>
        /// Получить всю таблицу ошибок.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="count"> Кол-во элементов на странице. </param>
        /// <returns></returns>
        public async Task<JsonResult> GetErrorAllTable(int page, int count)
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

            var table = await _errorService.GetErrorAllTableInfoAsync(page, count, errors);
            var tableDto = table != null ? _errorMappingService.TableInfoToTableFullInfoDto(table) : null;

            if (errors.Any())
            {
                return new JsonResult(new Result(errors));
            }

            return new JsonResult(new Result<TableInfoDto<ErrorFullInfoDto>>(tableDto, errors));
        }

        /// <summary>
        /// Удалить ошибку.
        /// </summary>
        /// <param name="id"> Идентификатор ошибки. </param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<JsonResult> Delete([FromBody] Guid id)
        {
            var errors = new List<string>();
            await _errorService.DeleteAsync(id, errors);
            return new JsonResult(new Result(errors));
        }

        /// <summary>
        /// Изменить статус ошибки.
        /// </summary>
        /// <param name="changeStatusErrorDto"> Информация для изменения статуса. </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> ChangeStatusError([FromBody] ChangeStatusErrorDto changeStatusErrorDto)
        {
            var errors = new List<string>();

            await _errorService.ChangeStatusError(changeStatusErrorDto.Id, changeStatusErrorDto.ErrorStatusId, errors);

            return new JsonResult(new Result(errors));
        }

        /// <summary>
        /// Получить статусы ошибки.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetErrorStatuses(Guid id)
        {
            var errors = new List<string>();
            var errorStatuses = await _errorStatusService.GetErrorStatuses(id, errors);
            return new JsonResult(new Result<List<ErrorStatus>>(errorStatuses, errors));
        }

        /// <summary>
        /// Получить статус ошибки.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetErrorStatus(Guid id)
        {
            var errors = new List<string>();

            var errorStatus = await _errorStatusService.GetErrorStatusOfError(id, errors);

            if (errorStatus is null)
            {
                errors.Add("Не удалось найти статус.");
            }

            return new JsonResult(new Result<string>(errorStatus?.Name, errors));
        }
    }
}
