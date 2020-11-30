using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using nhsuk.base_application.Extensions;
using nhsuk.base_application.Models;

namespace nhsuk.base_application.ServiceFilter
{
    public class RedirectEmptySessionData : IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Controller is Controller controller)
            {
                var userSessionData = controller.TempData.Get<UserSessionData>();
                if (userSessionData == null)
                {
                    context.Result = controller.RedirectToAction("Index");
                }
            }
        }
    }
}
