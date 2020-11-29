namespace Leonov.BugTracker.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Контроллер для рабоыт с комментарием.
    /// </summary>
    public class CommentaryController : Controller
    {
        [HttpPost]
        public Task<JsonResult> AddCommentary()
        {
            return null;
        }
    }
}
