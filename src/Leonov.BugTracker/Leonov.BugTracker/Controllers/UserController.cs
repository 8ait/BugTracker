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
        /// Получить пользователя по идентифкатору.
        /// </summary>
        /// <param name="id"> Идентификатор пользователя. </param>
        /// <returns> Страница пользователя </returns>
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _userService.GetAsync(id);
            if (user is null)
            {
                return NotFound();
            }

            var userDto = _userMappingService.UserInUserDto(user);
            return View("UserDetail", userDto);
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

        /// <summary>
        /// Получить таблицу пользователей.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="count"> Количество элементов на странице. </param>
        /// <returns> Таблица с пользователями. </returns>
        public async Task<JsonResult> GetUserTable(int page, int count)
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

            var table = await _userService.GetUserTableInfoAsync(page, count, errors);
            var tableDto = table != null ? _userMappingService.TableInfoToTableInfoDto(table) : null;

            if (errors.Any())
            {
                return new JsonResult(new Result(errors));
            }

            return new JsonResult(new Result<TableInfoDto<UserInfoDto>>(tableDto, errors));
        }
    }
}
