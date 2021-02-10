using Microsoft.AspNetCore.Mvc;

namespace ConfigurableRedirects.AspNetCore.Features.Redirects
{
    public class RedirectInstruction
    {
        public RedirectRuleType RuleType { get; set; }
        public string Name { get; set; }
        public RedirectResult RedirectResult { get; set; }
    }
}
