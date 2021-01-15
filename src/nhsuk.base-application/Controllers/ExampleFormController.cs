using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nhsuk.base_application.Extensions;
using nhsuk.base_application.Models;
using nhsuk.base_application.ServiceFilter;
using nhsuk.base_application.ViewModels;

namespace nhsuk.base_application.Controllers
{

    [ServiceFilter(typeof(ConfigSettingsAttribute))]
    public class ExampleFormController : Controller
    {
        private const string CookieName = "BaseAppId";

        public ExampleFormController()
        {

        }

        [Route("example-form")]
        [HttpGet]
        public IActionResult Index()
        {
            TempData.Clear();
            var userSessionData = new UserSessionData();

            if (!Request.Cookies.ContainsKey(CookieName))
            {
                var id = Guid.NewGuid();

                Response.Cookies.Append(
                    CookieName,
                    id.ToString(),
                    new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddDays(30)
                    });

                userSessionData.Id = id;
            }
            else
            {
                if (Request.Cookies.TryGetValue(CookieName, out string idString))
                {
                    userSessionData.Id = Guid.Parse(idString);
                }
                else
                {
                    var id = Guid.NewGuid();

                    Response.Cookies.Append(
                        CookieName,
                        id.ToString(),
                        new CookieOptions
                        {
                            Expires = DateTimeOffset.UtcNow.AddDays(30)
                        });

                    userSessionData.Id = id;
                }
            }

            TempData.Set(userSessionData);

            return View();
        }

        [ServiceFilter(typeof(RedirectEmptySessionData))]
        [Route("example-form/address")]
        [HttpGet]
        public IActionResult Address()
        {
            UserSessionData userSessionData = TempData.Get<UserSessionData>();
            AddressViewModel viewModel = userSessionData.Address;

            return View(viewModel);
        }

        [ServiceFilter(typeof(RedirectEmptySessionData))]
        [Route("example-form/address")]
        [HttpPost]
        public IActionResult Address(AddressViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            UserSessionData userSessionData = TempData.Get<UserSessionData>();
            userSessionData.Address = model;
            TempData.Set(userSessionData);

            return RedirectToAction(nameof(Summary));
        }

        [ServiceFilter(typeof(RedirectEmptySessionData))]
        [Route("example-form/summary")]
        [HttpGet]
        public IActionResult Summary()
        {
            UserSessionData userSessionData = TempData.Get<UserSessionData>();
            var viewModel = MapToSummmary(userSessionData);

            return View(viewModel);
        }

        private static SummaryViewModel MapToSummmary(UserSessionData userSessionData)
        {
            AddressViewModel address = userSessionData.Address;

            string formattedAddress = string.Join(", ", new[] {
                address.Line1,
                address.Line2,
                address.Town,
                address.County,
                address.Postcode
            }.Where(i => !string.IsNullOrEmpty(i)));

            return new SummaryViewModel
            {
                Address = formattedAddress
            };
        }
    }
}
