using System;

namespace ConfigurableRedirects.AspNetCore.Features.Redirects
{
    public interface IRedirectProvider
    {
        string GetRedirectUrl(RedirectRule redirectRule, Uri uri);
        bool Matches(RedirectRule redirectRule, Uri uri);
    }
}
