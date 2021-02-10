namespace ConfigurableRedirects.AspNetCore.Features.Redirects
{
    public class RedirectRule
    {
        public RedirectRuleType RuleType { get; set; }
        public string Name { get; set; }
        public string MatchRule { get; set; }
        public string RedirectInstruction { get; set; }
        public bool IncludeQueryStringInRedirect { get; set; }
    }

    public enum RedirectRuleType
    {
        Regex,
        DetailsLegacyUrlPaths
    }
}
