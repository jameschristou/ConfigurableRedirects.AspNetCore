using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ConfigurableRedirects.AspNetCore.Features.Redirects
{
    public class RedirectController : Controller
    {
        private readonly IRedirectService _redirectService;
        private readonly IRedirectLogger _redirectLogger;

        public RedirectController(IRedirectService redirectService, IRedirectLogger redirectLogger)
        {
            _redirectService = redirectService;
            _redirectLogger = redirectLogger;
        }

        public async Task<ActionResult> Redirect()
        {
            var redirect = _redirectService.GetRedirect();

            if (redirect?.RedirectResult != null)
            {
                _redirectLogger.Log(RedirectReason.DetailsLegacyRedirect, HttpContext.Request.Path.ToString(), redirect.RedirectResult.Url);

                return redirect.RedirectResult;
            }

            return NotFound();
        }
    }
}
