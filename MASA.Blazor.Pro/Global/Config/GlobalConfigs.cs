using BlazorComponent;
using MASA.Blazor.Pro.JsRuntime;

namespace MASA.Blazor.Pro.Global
{
    public class GlobalConfigs
    {
        CookieStorage? _cookieStorage;

        public GlobalConfigs()
        {

        }
        public GlobalConfigs(CookieStorage cookieStorage)
        {
            _cookieStorage = cookieStorage;
        }

        public static string LanguageCookieKey { get; set; } = "GlobalConfigs_Language";

        public string? Language { get; set; }

        public bool IsDark { get; set; }

        public bool NavigationMini { get; set; }

        public bool ExpandOnHover { get; set; }

        public void Initialize(IRequestCookieCollection cookies)
        {
            Language = cookies[LanguageCookieKey];
        }

        public void SaveChanges()
        {
            _cookieStorage?.SetItemAsync(LanguageCookieKey, Language);
        }

        public void Bind(GlobalConfigs globalConfig)
        {
            Language = globalConfig.Language;
            IsDark = globalConfig.IsDark;
            NavigationMini = globalConfig.NavigationMini;
        }
    }
}
