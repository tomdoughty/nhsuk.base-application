using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
    }
}
