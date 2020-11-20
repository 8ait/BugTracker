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
            var errors = new List<string>();

            if (userDto.Id == Guid.Empty)
                errors.Add("Id не может быть пустым.");

            if (string.IsNullOrWhiteSpace(userDto.Firstname))
                errors.Add("Имя не может быть пустым.");

            if (string.IsNullOrWhiteSpace(userDto.Surname))
                errors.Add("Фамилия не может быть пустой.");

            if (userDto.UserTypeId == Guid.Empty)
                errors.Add("Тип пользователя не может быть пустым.");

            if (!errors.Any())
            {
                var userInfo = _userMappingService.UserDtoInUserInfo(userDto);
                await _userService.UpdateUserInformation(userInfo, errors);
            }
            return new JsonResult(new Result(errors));
        }

        /// <summary>
        /// Обновить пароль пользвоателя.
        /// </summary>
        /// <param name="userPasswordUpdateDto"> Дто обновления пароля. </param>
        /// <returns> Объект результата. </returns>
        public async Task<JsonResult> EditUserPassword([FromBody] UserPasswordUpdateDto userPasswordUpdateDto)
        {
            var errors = new List<string>();

            if (userPasswordUpdateDto.Id == Guid.Empty)
                errors.Add("Идентификатор пользователя не может быть пустым");

            if (string.IsNullOrWhiteSpace(userPasswordUpdateDto.NewPassword))
                errors.Add("Новый пароль не может быть пустым");

            if (userPasswordUpdateDto.NewPassword != userPasswordUpdateDto.RepeatNewPassword)
                errors.Add("Повтор пароля не совпадает с паролем.");

            if (!errors.Any())
            {
                var userPasswordUpdate =
                    _userMappingService.UserPasswordUpdateDtoInuserPasswordUpdate(userPasswordUpdateDto);
                await _authoriseService.EditPasswordAsync(userPasswordUpdate, errors);
            }

            return new JsonResult(new Result(errors));
        }

        /// <summary>
        /// Получить текущего пользователя.
        /// </summary>
        /// <returns> Дто текущего пользователя. </returns>
        [HttpGet]
        public async Task<JsonResult> GetCurrentUser()
        {
            var errors = new List<string>();
            var user = await _authoriseService.GetCurrentUser();
            var userDto = _userMappingService.UserInUserDto(user);
            return new JsonResult(new Result<UserDto>(userDto, errors));
        }
    }
}
