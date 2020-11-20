namespace nhsuk.base_application.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;

    public class AdobeAnalyticsDigitalDataViewModel
    {
        public AdobeAnalyticsDigitalDataViewModel(HttpContext context)
        {
            string url = context.Request.PathBase + context.Request.Path;

            List<string> urlFragments =
                url?
                    .Trim()
                    .Split('/', StringSplitOptions.RemoveEmptyEntries)
                    .ToList()
                ?? new List<string>();
            var pageName = "nhs:web:";
            PageName = pageName + string.Join(":", urlFragments);

            Dictionary<string, string> categories = new Dictionary<string, string>
            {
                { "primaryCategory", urlFragments.Any() ? urlFragments[0] : "" }
            };

            var subCategoryUrlFragments = urlFragments.Skip(1).Select((f, i) => (f, i+1));
            foreach ((string urlFragment, int index) in subCategoryUrlFragments)
            {
                categories.Add($"subCategory{index}", urlFragment);
            }

            Categories = JsonConvert.SerializeObject(categories);
        }

        public string PageName { get; }

        public string Categories { get; }
    }
}
