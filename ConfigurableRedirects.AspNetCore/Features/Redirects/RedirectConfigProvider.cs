using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ConfigurableRedirects.AspNetCore.Features.Redirects
{
    public interface IRedirectConfigProvider
    {
        List<RedirectRule> Get();
    }

    public class RedirectConfigProvider : IRedirectConfigProvider
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger<RedirectConfigProvider> _logger;

        private static List<RedirectRule> _redirects = null;

        public RedirectConfigProvider(IWebHostEnvironment hostingEnvironment, ILogger<RedirectConfigProvider> logger)
        {
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;

            Init();
        }

        public List<RedirectRule> Get(string tenantName)
        {
            throw new NotImplementedException();
        }

        private void Init()
        {
            var fullpath = Path.Combine($"{_hostingEnvironment.ContentRootPath}/Features/Redirects/redirectsConfig.json");

            if (!File.Exists(fullpath))
            {
                _logger.LogError("Could not load redirect configuration file with path:{0}", fullpath);
                return;
            }

            var content = File.ReadAllText(fullpath);
            var config = JsonSerializer.Deserialize<RedirectConfigDto>(content);

            _redirects = config.Redirects;
        }

        public List<RedirectRule> Get()
        {
            return _redirects;
        }

        private class RedirectConfigDto
        {
            public List<RedirectRule> Redirects { get; set; }
        }
    }
}
