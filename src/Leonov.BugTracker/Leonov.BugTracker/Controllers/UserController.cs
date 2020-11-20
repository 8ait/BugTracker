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
    /// Контроллер для пользователей.
    /// </summary>
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserMappingService _userMappingService;
        private readonly IAuthoriseService _authoriseService;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="userService"> Сервис для работы с пользователями. </param>
        public UserController(
            IUserService userService,
            IUserMappingService userMappingService,
            IAuthoriseService authoriseService)
        {
            _authoriseService = authoriseService;
            _userService = userService;
            _userMappingService = userMappingService;
        }

        public IActionResult Index()
        {
            return View("UserList");
        }

        /// <summary>
        /// Редактировать информацию о текущем пользователе.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> EditUserInformation([FromBody] UserDto userDto)
        {
            var userInfo = _userMappingService.UserDtoInUserInfo(userDto);
            var errors = new List<string>();
            await _userService.UpdateUserInformation(userInfo, errors);
            return new JsonResult("asd");
        }

        /// <summary>
        /// Получить текущего пользователя.
        /// </summary>
        /// <returns> Дто текущего пользователя. </returns>
        [HttpGet]
        public async Task<JsonResult> GetCurrentUser()
        {
            var user = await _authoriseService.GetCurrentUser();
            var userDto = _userMappingService.UserInUserDto(user);
            return new JsonResult(userDto);
        }
    }
}
