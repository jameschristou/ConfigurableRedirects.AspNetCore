using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigurableRedirects.AspNetCore.Features.Redirects
{
    public class ConfigBasedRedirectRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            var redirectService = httpContext.RequestServices.GetService<IRedirectService>();

            return redirectService.CurrentRequestRequiresRedirect();
        }
    }
}
