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

    /// <summary>
    /// Администрирование.
    /// </summary>
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserMappingService _userMappingService;

        /// <summary>
        /// Контроллер.
        /// </summary>
        /// <param name="userService"></param>
        public AdminController(IUserService userService,
            IUserMappingService userMappingService)
        {
            _userService = userService;
            _userMappingService = userMappingService;
        }

        /// <summary>
        /// Главная страница.
        /// </summary>
        /// <returns></returns>
        [Auth(Arm.AdministratorPanel)]
        public IActionResult Index()
        {
            return View("Admin");
        }

        /// <summary>
        /// Получить все аккаунты.
        /// </summary>
        /// <returns></returns>
        [Auth(Arm.AdministratorPanel)]
        [HttpGet]
        public async Task<JsonResult> GetAccounts()
        {
            var errors = new List<string>();
            var users = await _userService.GetAll();
            var usersDto = users.Select(_userMappingService.UserInUserDto).ToList();
            return new JsonResult(new Result<List<UserDto>>(usersDto, errors));
        }

        /// <summary>
        /// Изменить активность аккаунта.
        /// </summary>
        /// <param name="chageDto"></param>
        /// <returns></returns>
        [Auth(Arm.AdministratorPanel)]
        [HttpPost]
        public async Task<JsonResult> ChangeAccountStatus([FromBody] ChangeAccountStatusDto changeDto)
        {
            var errors = new List<string>();
            await _userService.ChangeAccountStatus(changeDto.Id, changeDto.Active, errors);
            return new JsonResult(new Result(errors));
        }
    }
}
