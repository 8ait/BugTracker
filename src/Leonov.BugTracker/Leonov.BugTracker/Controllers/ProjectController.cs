namespace Leonov.BugTracker.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Контроллер для работы с проектами.
    /// </summary>
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View("ProjectList");
        }
    }
}
