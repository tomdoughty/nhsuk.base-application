using nhsuk.base_application.ViewModels;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace nhsuk.base_application.UnitTests.ViewModels
{
    [TestFixture]
    public class BreadcrumbViewModelTests
    {
        [Test]
        public void BreadcrumbLink_ViewModel_Test()
        {
            BreadcrumbLink breadcrumbLink = new BreadcrumbLink("www.testurl.com", "Test Url");
            Assert.AreEqual("www.testurl.com", breadcrumbLink.Url);
            Assert.AreEqual("Test Url", breadcrumbLink.Text);
        }

        [Test]
        public void Breadcrumb_ViewModel_Test()
        {
            List<BreadcrumbLink> links = new List<BreadcrumbLink> {
                new BreadcrumbLink("www.testurl1.com", "Test Url 1"),
                new BreadcrumbLink("www.testurl2.com", "Test Url 2")
            };

            BreadcrumbViewModel breadcrumb = new BreadcrumbViewModel(links);
            Assert.IsInstanceOf<IEnumerable<BreadcrumbLink>>(breadcrumb.Links);
            Assert.AreEqual(breadcrumb.Links.Count(), 3);
            Assert.AreEqual(breadcrumb.BackLink, links.LastOrDefault());
        }
    }
}
