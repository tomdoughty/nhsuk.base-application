namespace nhsuk.base_application.Configuration
{
    using Microsoft.Extensions.Configuration;
    public class AppSettings : IAppSettings
    {
        public AppSettings(IConfiguration configuration)
        {
            CookieScriptUrl = configuration["CookieScriptUrl"];
            AdobeAnalyticsScriptUrl = configuration["AdobeAnalyticsScriptUrl"];
        }
        public string CookieScriptUrl { get; set; }
        public string AdobeAnalyticsScriptUrl { get; set; }
    }

}
