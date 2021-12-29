namespace MASA.Blazor.Pro.Global
{
    public class GlobalConfigs
    {
        private readonly CookieStorage? _cookieStorage;
        private bool _isDark;
        private bool _expandOnHover;
        private bool _navigationMini;
        private string? _language;
        private string? _favorite;

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

        public string? Language
        {
            get => _language;
            set
            {
                _language = value;
                _cookieStorage?.SetItemAsync(LanguageCookieKey, value);
            }
        }
        
        public bool IsDark
        {
            get => _isDark;
            set
            {
                _isDark = value;
                _cookieStorage?.SetItemAsync(IsDarkCookieKey, value);
            }
        }

        public bool NavigationMini
        {
            get => _navigationMini;
            set
            {
                _navigationMini = value;
                _cookieStorage?.SetItemAsync(NavigationMiniCookieKey, value);
            }
        }
        
        public bool ExpandOnHover
        {
            get => _expandOnHover;
            set
            {
                _expandOnHover = value;
                _cookieStorage?.SetItemAsync(ExpandOnHoverCookieKey, value);
            }
        }
        
        public string? Favorite
        {
            get => _favorite;
            set
            {
                _favorite = value;
                _cookieStorage?.SetItemAsync(FavoriteCookieKey, value);
            }
        }

        public void Initialization(IRequestCookieCollection cookies)
        {
            _language = cookies[LanguageCookieKey];
            _isDark = Convert.ToBoolean(cookies[IsDarkCookieKey]);
            _navigationMini = Convert.ToBoolean(cookies[NavigationMiniCookieKey]);
            _expandOnHover = Convert.ToBoolean(cookies[ExpandOnHoverCookieKey]);
            _favorite = cookies[FavoriteCookieKey];
        }

        public void Bind(GlobalConfigs globalConfig)
        {
            _language = globalConfig.Language;
            _isDark = globalConfig.IsDark;
            _navigationMini = globalConfig.NavigationMini;
            _expandOnHover = globalConfig.ExpandOnHover;
            _favorite = globalConfig.Favorite;
        }
    }
}
