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
        private RedirectInstruction _redirectInstruction;

        public bool CurrentRequestRequiresRedirect()
        {
            throw new NotImplementedException();
        }

        public RedirectInstruction GetRedirect()
        {
            if (_redirectInstruction != null) return _redirectInstruction;

            _redirectInstruction = GetRedirectInstructionForRequest() ?? new RedirectInstruction();

            return _redirectInstruction;
        }

        private RedirectInstruction GetRedirectInstructionForRequest()
        {
            throw new NotImplementedException();
        }
    }
}
