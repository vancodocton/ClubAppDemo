using Microsoft.AspNetCore.Authentication.Cookies;

namespace ClubApp.MvcClient.Configs
{
    public static class ConfigureCookieSettings
    {
        public static IServiceCollection AddCookieSettings(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                //options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                //options.Cookie.Name = "YourAppCookieName";
                options.Cookie.IsEssential = true;
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                //options.LoginPath = "/Identity/Account/Login";

                // ReturnUrlParameter requires 
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;

                options.SlidingExpiration = true;
                options.Cookie.SameSite = SameSiteMode.Lax;
            });

            return services;
        }
    }
}
