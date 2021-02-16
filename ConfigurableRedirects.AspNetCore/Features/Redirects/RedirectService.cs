using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Linq;

namespace ConfigurableRedirects.AspNetCore.Features.Redirects
{
    public interface IRedirectService
    {
        RedirectInstruction GetRedirect();
        bool CurrentRequestRequiresRedirect();
    }

    public class RedirectService : IRedirectService
    {
        private readonly IRedirectConfigProvider _redirectConfigProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private RedirectInstruction _redirectInstruction;

        public RedirectService(IRedirectConfigProvider redirectConfigProvider, IHttpContextAccessor httpContextAccessor)
        {
            _redirectConfigProvider = redirectConfigProvider;
            _httpContextAccessor = httpContextAccessor;
        }

        public bool CurrentRequestRequiresRedirect()
        {
            var redirectRules = _redirectConfigProvider.Get();

            // check whether any of the redirect rules apply to this request
            return redirectRules != null && redirectRules.Any(rule =>
            {
                var redirectRuleProvider = rule.GetRedirectProvider(_httpContextAccessor.HttpContext);
                return redirectRuleProvider.Matches(rule, new Uri(_httpContextAccessor.HttpContext.Request.GetEncodedUrl()));
            });
        }

        public RedirectInstruction GetRedirect()
        {
            if (_redirectInstruction != null) return _redirectInstruction;

            _redirectInstruction = GetRedirectInstructionForRequest() ?? new RedirectInstruction();

            return _redirectInstruction;
        }

        private RedirectInstruction GetRedirectInstructionForRequest()
        {
            var redirectRules = _redirectConfigProvider.Get();

            if (redirectRules == null || !redirectRules.Any()) return null;

            // loop through and try to find a match
            foreach (var redirectRule in redirectRules)
            {
                var redirectInstruction = redirectRule.GetRedirectInstruction(_httpContextAccessor.HttpContext);

                if (redirectInstruction != null)
                {
                    return redirectInstruction;
                }
            }

            return null;
        }
    }
}
