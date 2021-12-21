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

        public static string IsDarkCookieKey { get; set; } = "GlobalConfigs_IsDark";

        public static string NavigationMiniCookieKey { get; set; } = "GlobalConfigs_NavigationMini";

        public static string ExpandOnHoverCookieKey { get; set; } = "GlobalConfigs_ExpandOnHover";

        public static string FavoriteCookieKey { get; set; } = "GlobalConfigs_Favorite";

        private string? _language;
        public string? Language
        {
            get => _language;
            set
            {
                _language = value;
                _cookieStorage?.SetItemAsync(LanguageCookieKey, value);
            }
        }

        private bool _isDark;
        public bool IsDark
        {
            get => _isDark;
            set
            {
                _isDark = value;
                _cookieStorage?.SetItemAsync(IsDarkCookieKey, value);
            }
        }

        private bool _navigationMini;
        public bool NavigationMini
        {
            get => _navigationMini;
            set
            {
                _navigationMini = value;
                _cookieStorage?.SetItemAsync(NavigationMiniCookieKey, value);
            }
        }

        private bool _expandOnHover;
        public bool ExpandOnHover
        {
            get => _expandOnHover;
            set
            {
                _expandOnHover = value;
                _cookieStorage?.SetItemAsync(ExpandOnHoverCookieKey, value);
            }
        }

        private string? _Favorite;
        public string? Favorite
        {
            get => _Favorite;
            set
            {
                _Favorite = value;
                _cookieStorage?.SetItemAsync(FavoriteCookieKey, value);
            }
        }

        public void Initialization(IRequestCookieCollection cookies)
        {
            _language = cookies[LanguageCookieKey];
            _isDark = Convert.ToBoolean(cookies[IsDarkCookieKey]);
            _navigationMini = Convert.ToBoolean(cookies[NavigationMiniCookieKey]);
            _expandOnHover = Convert.ToBoolean(cookies[ExpandOnHoverCookieKey]);
            _Favorite = cookies[FavoriteCookieKey];
        }

        //public void SaveChanges()
        //{
        //    _cookieStorage?.SetItemAsync(LanguageCookieKey, Language);
        //    _cookieStorage?.SetItemAsync(IsDarkCookieKey, IsDark);
        //    _cookieStorage?.SetItemAsync(NavigationMiniCookieKey, NavigationMini);
        //    _cookieStorage?.SetItemAsync(ExpandOnHoverCookieKey, ExpandOnHover);
        //}

        public void Bind(GlobalConfigs globalConfig)
        {
            _language = globalConfig.Language;
            _isDark = globalConfig.IsDark;
            _navigationMini = globalConfig.NavigationMini;
            _expandOnHover = globalConfig.ExpandOnHover;
            _Favorite = globalConfig.Favorite;
        }
    }
}
