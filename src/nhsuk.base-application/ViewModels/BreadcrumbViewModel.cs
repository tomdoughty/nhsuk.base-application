using System.Collections.Generic;
using System.Linq;

namespace nhsuk.base_application.ViewModels
{
    public class BreadcrumbViewModel
    {
        public BreadcrumbViewModel(IEnumerable<BreadcrumbLink> links)
        {
            Links = new[] { new BreadcrumbLink("/", "Home") }.Union(links).ToArray();
        }

        public IEnumerable<BreadcrumbLink> Links { get; }

        public BreadcrumbLink BackLink => Links.LastOrDefault();

    }
    public class BreadcrumbLink
    {
        public BreadcrumbLink(string url, string text)
        {
            Url = url;
            Text = text;
        }

        public object Url { get; }

        public object Text { get; }
    }

}
