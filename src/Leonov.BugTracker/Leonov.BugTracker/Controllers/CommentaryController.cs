namespace Leonov.BugTracker.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Leonov.BugTracker.Authenticate;
    using Leonov.BugTracker.Domain.Interfaces;
    using Leonov.BugTracker.Dto;
    using Leonov.BugTracker.Services.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Контроллер для рабоыт с комментарием.
    /// </summary>
    public class CommentaryController : Controller
    {
        private readonly ICommentaryService _commentaryService;
        private readonly ICommentaryMapping _commentaryMapping;
        private readonly IAuthoriseService _authoriseService;

        public CommentaryController(ICommentaryService commentaryService,
            ICommentaryMapping commentaryMapping,
            IAuthoriseService authoriseService)
        {
            _commentaryService = commentaryService;
            _commentaryMapping = commentaryMapping;
            _authoriseService = authoriseService;
        }

        [HttpGet]
        [Auth(Arm.Default)]
        public async Task<JsonResult> GetCommentariesByError(Guid errorId)
        {
            var errors = new List<string>();
            var commentaries = await _commentaryService.GetCommentariesByError(errorId, errors);
            var commentariesDtos = _commentaryMapping.CommentariesToComeCommentaryInfoDtos(commentaries);
            return new JsonResult(new Result<List<CommentaryInfoDto>>(commentariesDtos, errors));
        }

        [HttpGet]
        [Auth(Arm.Default)]
        public async Task<JsonResult> GetUserCommentaryInfo([FromServices] IAuthoriseService authoriseService, Guid? userId = null)
        {
            var errors = new List<string>();
            Guid id;
            if (userId is null)
            {
                id = (await authoriseService.GetCurrentUser()).Id;
            }
            else
            {
                id = userId.Value;
            }
            var result = new UserCommentaryInfoDto()
            {
                CommentaryCount = await _commentaryService.GetCountOfUserCommentaries(id, errors),
                Popularity = await _commentaryService.GetPopularityOfUser(id, errors)
            };
            if (errors.Any())
            {
                return new JsonResult(new Result(errors));
            }

            return new JsonResult(new Result<UserCommentaryInfoDto>(result, errors));
        }

        [HttpPost]
        [Auth(Arm.Default)]
        public async Task<JsonResult> AddCommentary([FromBody] AddCommentaryDto addCommentaryDto)
        {
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(addCommentaryDto.Value))
            {
                errors.Add("Значение комментария не может быть пустым.");
                return new JsonResult(new Result(errors));
            }
            var commentary = _commentaryMapping.AddCommentaryDtoToCommentary(addCommentaryDto);
            var user = await _authoriseService.GetCurrentUser();
            if (user is null)
            {
                errors.Add("Не найден пользвоатель");
                return new JsonResult(new Result(errors));
            }

            commentary.UserId = user.Id;
            await _commentaryService.CreateAsync(commentary, errors);

            return new JsonResult(new Result(errors));
        }
    }
}
