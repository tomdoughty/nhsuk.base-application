using System.Collections.Generic;
using nhsuk.base_application.Models;

namespace nhsuk.base_application.ViewModels
{
    public sealed class ResultViewModel
    {
        public string Org { get; set; }

        public List<Result> Results { get; set; }

    }

}
