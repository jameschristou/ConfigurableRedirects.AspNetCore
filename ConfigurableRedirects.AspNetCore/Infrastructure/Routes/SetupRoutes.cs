using ConfigurableRedirects.AspNetCore.Features.Redirects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace ConfigurableRedirects.AspNetCore.Infrastructure.Routes
{
    public static class SetupRoutesExtensions
    {
        public static void SetupRoutes(this IEndpointRouteBuilder routeBuilder)
        {
            routeBuilder.MapControllerRoute("Redirects", 
                            "{*url}", 
                            new { controller = "Redirect", action = "Redirect" },
                            new { url = new ConfigBasedRedirectRouteConstraint() }
                            );

            routeBuilder.MapControllerRoute(
                            name: "default",
                            pattern: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
