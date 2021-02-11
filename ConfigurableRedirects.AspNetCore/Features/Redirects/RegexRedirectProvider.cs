using System;
using System.Text.RegularExpressions;

namespace ConfigurableRedirects.AspNetCore.Features.Redirects
{
    public class RegexRedirectProvider : IRedirectProvider
    {
        public string GetRedirectUrl(RedirectRule redirectRule, Uri uri)
        {
            var regex = new Regex(redirectRule.MatchRule, RegexOptions.IgnoreCase);

            var absolutePathUnescaped = Uri.UnescapeDataString(uri.AbsolutePath);

            var matches = regex.Matches(absolutePathUnescaped);

            if (matches.Count != 1) return null;

            return Regex.Replace(absolutePathUnescaped, redirectRule.MatchRule, redirectRule.RedirectInstruction, RegexOptions.IgnoreCase);
        }

        public bool Matches(RedirectRule redirectRule, Uri uri)
        {
            return new Regex(redirectRule.MatchRule, RegexOptions.IgnoreCase).IsMatch($"/{Uri.UnescapeDataString(uri.AbsolutePath).Trim('/')}/");
        }
    }
}
