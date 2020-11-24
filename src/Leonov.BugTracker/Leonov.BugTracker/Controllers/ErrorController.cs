using Microsoft.AspNetCore.Mvc;

namespace Leonov.BugTracker.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Leonov.BugTracker.Domain.Interfaces;
    using Leonov.BugTracker.Dto;
    using Leonov.BugTracker.Services.Interfaces;

    /// <summary>
    /// Контроллер для ошибок.
    /// </summary>
    public class ErrorController : Controller
    {
        private readonly IErrorService _errorService;
        private readonly IErrorMappingService _errorMappingService;

        /// <summary>
        /// Контроллер.
        /// </summary>
        /// <param name="errorService">  </param>
        /// <param name="errorMappingService"></param>
        public ErrorController(IErrorService errorService, IErrorMappingService errorMappingService)
        {
            _errorService = errorService;
            _errorMappingService = errorMappingService;
        }

        public IActionResult Index()
        {
            return null;
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
    }
}
