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

        [Route("")]
        [HttpGet]
        public IActionResult Index() => View();
    }
}
