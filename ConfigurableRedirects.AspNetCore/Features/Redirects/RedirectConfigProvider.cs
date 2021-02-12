using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurableRedirects.AspNetCore.Features.Redirects
{
    public interface IRedirectConfigProvider
    {
        List<RedirectRule> Get(string tenantName);
    }

    public class RedirectConfigProvider : IRedirectConfigProvider
    {
        public List<RedirectRule> Get(string tenantName)
        {
            throw new NotImplementedException();
        }
    }
}
