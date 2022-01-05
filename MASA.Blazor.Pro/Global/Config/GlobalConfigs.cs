namespace MASA.Blazor.Pro.Global;

public class GlobalConfigs
{
    private bool _isDark;
    private bool _expandOnHover;
    private bool _navigationMini;
    private string? _favorite;
    private CookieStorage? _cookieStorage;
    private I18nConfig? _i18nConfig;

    public static string IsDarkCookieKey { get; set; } = "GlobalConfigs_IsDark";

    public static string NavigationMiniCookieKey { get; set; } = "GlobalConfigs_NavigationMini";

    public static string ExpandOnHoverCookieKey { get; set; } = "GlobalConfigs_ExpandOnHover";

    public static string FavoriteCookieKey { get; set; } = "GlobalConfigs_Favorite";

    public string? Language
    {
        get => _i18nConfig?.Language;
        set
        {
            if (_i18nConfig is not null) _i18nConfig.Language = value;
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

    public GlobalConfigs()
    {

    }

    public GlobalConfigs(CookieStorage cookieStorage, I18nConfig i18nConfig)
    {
        _cookieStorage = cookieStorage;
        _i18nConfig = i18nConfig;
    }

    public void Initialization(IRequestCookieCollection cookies)
    {
        _isDark = Convert.ToBoolean(cookies[IsDarkCookieKey]);
        _navigationMini = Convert.ToBoolean(cookies[NavigationMiniCookieKey]);
        _expandOnHover = Convert.ToBoolean(cookies[ExpandOnHoverCookieKey]);
        _favorite = cookies[FavoriteCookieKey];
    }

    public async Task Initialization()
    {
        if (_cookieStorage is not null)
        {
            _isDark = Convert.ToBoolean(await _cookieStorage.GetCookie(IsDarkCookieKey));
            _navigationMini = Convert.ToBoolean(await _cookieStorage.GetCookie(NavigationMiniCookieKey));
            _expandOnHover = Convert.ToBoolean(await _cookieStorage.GetCookie(ExpandOnHoverCookieKey));
            _favorite = await _cookieStorage.GetCookie(FavoriteCookieKey);
        }
    }

    public void Bind(GlobalConfigs globalConfig, I18nConfig i18nConfig)
    {
        _i18nConfig?.Bind(i18nConfig);
        _isDark = globalConfig.IsDark;
        _navigationMini = globalConfig.NavigationMini;
        _expandOnHover = globalConfig.ExpandOnHover;
        _favorite = globalConfig.Favorite;
    }
}

