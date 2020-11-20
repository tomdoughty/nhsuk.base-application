using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using nhsuk.base_application.Models;
using nhsuk.base_application.ServiceFilter;

namespace nhsuk.base_application.Controllers
{

    [ServiceFilter(typeof(ConfigSettingsAttribute))]
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            ViewData["Breadcrumbs"] = new BreadcrumbViewModel(new List<BreadcrumbLink>());
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
