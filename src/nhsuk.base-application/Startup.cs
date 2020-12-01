using System;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using nhsuk.base_application.Configuration;
using nhsuk.base_application.ServiceFilter;
// using NhsUk.HeaderFooterApiClient;
// using NhsUk.HeaderFooterApiClient.Interfaces;
// using NhsUk.HeaderFooterApiClient.Models;

namespace nhsuk.base_application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAntiforgery(options => options.Cookie.SecurePolicy = CookieSecurePolicy.Always);

            services.AddControllersWithViews();

            services.AddHttpClient();

            services.AddSingleton<IAppSettings, AppSettings>();

            services.AddScoped<ConfigSettingsAttribute>();

            services.AddScoped<RedirectEmptySessionData>();

            services.Configure<CookieTempDataProviderOptions>(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });

            // Uncomment to use the header and footer Nuget package
            // services.AddScoped<IHeaderFooterApiClientReader, HeaderFooterApi>(sp =>
            // {
            //     var apiReaderOptions = new ApiReaderOptions(
            //         sp.GetService<IHttpClientFactory>(),
            //         Guid.Parse(Configuration["HeaderFooterApi:SubscriptionKey"]),
            //         Configuration["HeaderFooterApi:EndPointBaseUrl"]
            //     );
            //     return new HeaderFooterApi(apiReaderOptions, sp.GetService<IMemoryCache>(),
            //         int.Parse(Configuration["HeaderFooterApi:CacheExpiryTimeInMinutes"]), sp.GetService<ILogger<HeaderFooterApi>>());
            // });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UsePathBase("/service-name");

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
