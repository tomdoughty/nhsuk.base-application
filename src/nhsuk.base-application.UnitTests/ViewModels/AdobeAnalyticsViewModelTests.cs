using Microsoft.AspNetCore.Http;
using nhsuk.base_application.Configuration;
using nhsuk.base_application.ViewModels;
using NUnit.Framework;
using Moq;

namespace nhsuk.base_application.UnitTests.ViewModels
{
    [TestFixture]
    public class AdobeAnalyticsViewModelTests
    {
        private AdobeAnalyticsViewModel _viewModel;
        private Mock<IAppSettings> _mockConfiguration;
        private Mock<HttpContext> _mockContext;

        [OneTimeSetUp]
        public void SetUp()
        {
            _mockConfiguration = new Mock<IAppSettings>();
            _mockConfiguration.Setup(s => s.AdobeAnalyticsScriptUrl).Returns("www.test.com");


            _mockContext = new Mock<HttpContext>();
            _mockContext.Setup(x => x.Request.PathBase).Returns(new PathString("/service-name"));

            _viewModel = new AdobeAnalyticsViewModel(_mockContext.Object, _mockConfiguration.Object);
        }

        [Test]
        public void AdobeAnalytics_ViewModel_Test()
        {
            Assert.AreEqual(_viewModel.ScriptUrl, "www.test.com");
            Assert.AreEqual(_viewModel.PageName, "nhs:web:service-name");
            Assert.AreEqual(_viewModel.Categories, @"{""primaryCategory"":""service-name""}");
        }
    }
}
