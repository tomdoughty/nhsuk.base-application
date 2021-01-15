using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using nhsuk.base_application.Models;
using nhsuk.base_application.ServiceFilter;
using nhsuk.base_application.ViewModels;
using nhsuk.base_application.Repositories;
using System.Collections.Generic;

namespace nhsuk.base_application.Controllers
{

    [ServiceFilter(typeof(ConfigSettingsAttribute))]
    public class ExampleAsyncController : Controller
    {
        private readonly IResultsRepository _resultsRepository;

        public ExampleAsyncController(IResultsRepository resultsRepository)
        {
            _resultsRepository = resultsRepository;
        }

        [Route("example-async")]
        [HttpGet]
        public async Task<IActionResult> ApiResult(string org)
        {
            List<Result> results = await _resultsRepository.GetResults(org);

            ResultViewModel viewModel = new ResultViewModel()
            {
                Org = org,
                Results = results
            };

            return View(viewModel);
        }
    }
}
