using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConfigurableRedirects.AspNetCore.Features.Redirects
{
    public static class RedirectRuleExtensions
    {
        public static RedirectInstruction GetRedirectInstruction(this RedirectRule input, HttpContext httpContext)
        {
            var uri = new Uri(httpContext.Request.GetEncodedUrl());
            var redirectProvider = input.GetRedirectProvider(httpContext);
            var redirectUrl = redirectProvider?.GetRedirectUrl(input, uri);

            if (string.IsNullOrEmpty(redirectUrl)) return null;

            if (input.IncludeQueryStringInRedirect && !string.IsNullOrEmpty(uri.Query))
            {
                redirectUrl = $"{redirectUrl}{uri.Query}";
            }

            return new RedirectInstruction()
            {
                Name = input.Name,
                RuleType = input.RuleType,
                RedirectResult = new RedirectResult(redirectUrl, true)
            };
        }

        public static IRedirectProvider GetRedirectProvider(this RedirectRule redirectRule, HttpContext httpContext)
        {
            switch (redirectRule.RuleType)
            {
                case RedirectRuleType.Regex:
                    return httpContext.RequestServices.GetService<RegexRedirectProvider>();
                default: return null;
            }
        }
    }
}
