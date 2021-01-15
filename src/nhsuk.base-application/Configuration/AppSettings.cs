namespace nhsuk.base_application.Configuration
{
    using Microsoft.Extensions.Configuration;

    public class AppSettings : IAppSettings
    {
        public AppSettings(IConfiguration configuration)
        {
            CookieScriptUrl = configuration["CookieScriptUrl"];
            AdobeAnalyticsScriptUrl = configuration["AdobeAnalyticsScriptUrl"];
            ResultsApiEndpoint = configuration["ResultsApiEndpoint"];
        }
        public string CookieScriptUrl { get; set; }
        public string AdobeAnalyticsScriptUrl { get; set; }
        public string ResultsApiEndpoint { get; set; }
    }

}
