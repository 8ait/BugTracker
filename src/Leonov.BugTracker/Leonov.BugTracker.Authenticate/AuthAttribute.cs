namespace Leonov.BugTracker.Authenticate
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Net;

    using Leonov.BugTracker.Domain.Interfaces;

    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Фильтер на проверку определенного АРМа.
    /// </summary>
    public class AuthAttribute: Attribute, IAuthorizationFilter
    {
        /// <summary>
        /// Наименование АРМа.
        /// </summary>
        private readonly Arm _arm;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="armName"> Название АРМа. </param>
        public AuthAttribute(Arm arm)
        {
            _arm = arm;
        }

        private string Description(Arm arm)
        {
            var enumType = typeof(Arm);
            var memberInfos = enumType.GetMember(arm.ToString());
            var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
            var valueAttributes =
                enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            var description = ((DescriptionAttribute)valueAttributes[0]).Description;
            return description;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var auth = context.HttpContext.RequestServices.GetService<IAuthoriseService>();
            if (!auth.IsAuthorized())
                context.Result = new RedirectToActionResult("Index", "Auth", context.RouteData.Values);
            var arms = auth.GetCurrentArms();
            if (_arm != Arm.Default && !arms.Select(x => x.Name).Contains(Description(_arm)))
            {
                context.Result = new StatusCodeResult(403);
            }
        }
    }
}
