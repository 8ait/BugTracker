namespace Leonov.BugTracker.Authenticate
{
    using Leonov.BugTracker.Domain.Interfaces;

    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Фильтер на проверку определенного АРМа.
    /// </summary>
    public class AuthAttribute: ResultFilterAttribute
    {
        /// <summary>
        /// Наименование АРМа.
        /// </summary>
        private readonly string _armName;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="armName"> Название АРМа. </param>
        public AuthAttribute(string armName)
        {
            _armName = armName;
        }

        /// <inheritdoc />
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var auth = context.HttpContext.RequestServices.GetService<IAuthoriseService>();
            if (!auth.IsAuthorized())
                context.Result = new RedirectToActionResult("Index","Auth", context.RouteData.Values);
            base.OnResultExecuting(context);
        }
    }
}
