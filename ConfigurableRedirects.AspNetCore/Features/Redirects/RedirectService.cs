using System;

namespace ConfigurableRedirects.AspNetCore.Features.Redirects
{
    public interface IRedirectService
    {
        RedirectInstruction GetRedirect();
        bool CurrentRequestRequiresRedirect();
    }

    public class RedirectService : IRedirectService
    {
        public bool CurrentRequestRequiresRedirect()
        {
            throw new NotImplementedException();
        }

        public RedirectInstruction GetRedirect()
        {
            throw new NotImplementedException();
        }
    }
}
