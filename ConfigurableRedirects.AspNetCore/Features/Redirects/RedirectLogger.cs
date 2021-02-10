using Microsoft.Extensions.Logging;

namespace ConfigurableRedirects.AspNetCore.Features.Redirects
{
    public interface IRedirectLogger
    {
        void Log(RedirectReason reason, string requestUrl, string redirectUrl);
    }

    public class RedirectLogger : IRedirectLogger
    {
        private readonly ILogger<RedirectLogger> _logger;

        public RedirectLogger(ILogger<RedirectLogger> logger)
        {
            _logger = logger;
        }

        public void Log(RedirectReason reason, string requestUrl, string redirectUrl)
        {
            _logger.LogInformation("Redirect:{0}: {1} -> {2}", reason.ToString(), requestUrl, redirectUrl);
        }
    }

    public enum RedirectReason
    {
        DetailsCanonicalRedirect,
        DetailsLegacyRedirect
    }
}
