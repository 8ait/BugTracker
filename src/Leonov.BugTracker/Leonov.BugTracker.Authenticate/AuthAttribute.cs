﻿namespace Leonov.BugTracker.Authenticate
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc;

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
            context.Result = new RedirectToActionResult("Index","Auth", context.RouteData.Values);
            base.OnResultExecuting(context);
        }
    }
}
