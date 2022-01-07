namespace MASA.Blazor.Pro.Global;

public class GlobalConfig
{
    #region Field

    private bool _isDark;
    private bool _expandOnHover;
    private bool _navigationMini;
    private string? _favorite;
    private CookieStorage? _cookieStorage;

    #endregion

    #region Property

    public static string IsDarkCookieKey { get; set; } = "GlobalConfig_IsDark";

    public static string NavigationMiniCookieKey { get; set; } = "GlobalConfig_NavigationMini";

    public static string ExpandOnHoverCookieKey { get; set; } = "GlobalConfig_ExpandOnHover";

    public static string FavoriteCookieKey { get; set; } = "GlobalConfig_Favorite";

    public I18nConfig? I18nConfig { get; set; }

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

    #endregion

    /// <summary>
    /// 别删，大锅
    /// </summary>
    public GlobalConfig() { }

    public GlobalConfig(CookieStorage cookieStorage, I18nConfig i18nConfig)
    {
        _cookieStorage = cookieStorage;
        I18nConfig = i18nConfig;
    }

    #region Method

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

    public void Bind(GlobalConfig globalConfig)
    {
        I18nConfig?.Bind(globalConfig.I18nConfig);
        _isDark = globalConfig.IsDark;
        _navigationMini = globalConfig.NavigationMini;
        _expandOnHover = globalConfig.ExpandOnHover;
        _favorite = globalConfig.Favorite;
    }

    #endregion
}