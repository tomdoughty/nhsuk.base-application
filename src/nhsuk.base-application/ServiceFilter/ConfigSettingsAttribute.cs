namespace nhsuk.base_application.ServiceFilter
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using nhsuk.base_application.Configuration;
    using nhsuk.base_application.ViewModels;

    public class ConfigSettingsAttribute : IActionFilter
    {
        private readonly IAppSettings _appSetting;

        public ConfigSettingsAttribute(IAppSettings appSettings)
        {
            _appSetting = appSettings;
        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Controller is Controller controller)
            {
                AdobeAnalyticsViewModel AdobeAnalyticsData = new AdobeAnalyticsViewModel(context.HttpContext, _appSetting);
                BreadcrumbViewModel BreadcrumbData = new BreadcrumbViewModel(new List<BreadcrumbLink>());

                controller.ViewBag.CookieScriptUrl = _appSetting.CookieScriptUrl;
                controller.ViewBag.AdobeAnalytics = AdobeAnalyticsData;
                controller.ViewBag.Breadcrumbs = BreadcrumbData;
            }
        }
    }
}
