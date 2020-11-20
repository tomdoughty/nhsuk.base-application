namespace nhsuk.base_application.Configuration
{
    using Microsoft.Extensions.Configuration;
    public class AppSettings : IAppSettings
    {
        public AppSettings(IConfiguration configuration)
        {
            CookiebotUrl = configuration["CookiebotUrl"];
            AdobeAnalyticsScriptUrl = configuration["AdobeAnalyticsScriptUrl"];
        }
        public string CookiebotUrl { get; set; }
        public string AdobeAnalyticsScriptUrl { get; set; }
    }

}
