using FactoryProject.Contracts;
using FactoryProject.Services;
using FactoryProject.Infrastructure.Utilities;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;

namespace FactoryProject.Infrastructure.Extensions;


public static class ServicesExtensions
{
    public static void ConfigureApiSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<TokenContainer>();
        services.AddScoped<TokenHandler>();
        services.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));
        services.AddHttpClient("FactoryApi", client =>
        {
            var apiSettings = configuration.GetSection("ApiSettings").Get<ApiSettings>();
            client.BaseAddress = new Uri(apiSettings?.BaseUrl ?? string.Empty);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        })
        .AddHttpMessageHandler<TokenHandler>();
    }
    public static void ConfigureAuthentication(this IServiceCollection services)
    {
        services.Configure<CookiePolicyOptions>(options =>
        {
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy=SameSiteMode.None;
        });
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessDenied";
            
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            });
        services.AddAuthorization();

        services.AddHttpContextAccessor();
        services.AddScoped<HttpContextAccessor>();

        services.AddHttpClient();
        services.AddScoped<HttpClient>();

      
    }
    
}