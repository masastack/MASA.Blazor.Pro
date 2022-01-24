namespace MASA.Blazor.Pro.Global;

public class GlobalConfig
{
    #region Field

    private bool _isDark;
    private string? _pageMode;
    private bool _expandOnHover;
    private bool _navigationMini;
    private string? _favorite;
    private NavModel? _currentNav;
    private CookieStorage? _cookieStorage;   

    #endregion

    #region Property

    public static string IsDarkCookieKey { get; set; } = "GlobalConfig_IsDark";

    public static string PageModeKey { get; set; } = "GlobalConfig_PageMode";

    public static string NavigationMiniCookieKey { get; set; } = "GlobalConfig_NavigationMini";

    public static string ExpandOnHoverCookieKey { get; set; } = "GlobalConfig_ExpandOnHover";

    public static string FavoriteCookieKey { get; set; } = "GlobalConfig_Favorite";

    public I18nConfig? I18nConfig { get; set; }

    public string? Language
    {
        get => I18nConfig?.Language;
        set 
        {
            if(I18nConfig is not null)
            {
                I18nConfig.Language = value;
                OnLanguageChanged?.Invoke();
            }           
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

    public string PageMode
    {
        get => _pageMode ?? PageModes.PageTab;
        set
        {
            _pageMode = value;
            _cookieStorage?.SetItemAsync(PageModeKey, value);
            OnPageModeChanged?.Invoke();
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

    public NavModel? CurrentNav
    {
        get => _currentNav;
        set
        {
            _currentNav = value;
            OnCurrentNavChanged?.Invoke();
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

    #region event

    public delegate void GlobalConfigChanged();
    public event GlobalConfigChanged? OnPageModeChanged;
    public event GlobalConfigChanged? OnCurrentNavChanged;
    public event GlobalConfigChanged? OnLanguageChanged;

    #endregion

    #region Method

    public void Initialization(IRequestCookieCollection cookies)
    {
        _isDark = Convert.ToBoolean(cookies[IsDarkCookieKey]);
        _pageMode = cookies[PageModeKey];
        _navigationMini = Convert.ToBoolean(cookies[NavigationMiniCookieKey]);
        _expandOnHover = Convert.ToBoolean(cookies[ExpandOnHoverCookieKey]);
        _favorite = cookies[FavoriteCookieKey];
    }

    public async Task Initialization()
    {
        if (_cookieStorage is not null)
        {
            _isDark = Convert.ToBoolean(await _cookieStorage.GetCookie(IsDarkCookieKey));
            _pageMode = await _cookieStorage.GetCookie(PageModeKey);
            _navigationMini = Convert.ToBoolean(await _cookieStorage.GetCookie(NavigationMiniCookieKey));
            _expandOnHover = Convert.ToBoolean(await _cookieStorage.GetCookie(ExpandOnHoverCookieKey));
            _favorite = await _cookieStorage.GetCookie(FavoriteCookieKey);
        }
    }

    public void Bind(GlobalConfig globalConfig)
    {
        I18nConfig?.Bind(globalConfig.I18nConfig);
        _isDark = globalConfig.IsDark;
        _pageMode = globalConfig.PageMode;
        _navigationMini = globalConfig.NavigationMini;
        _expandOnHover = globalConfig.ExpandOnHover;
        _favorite = globalConfig.Favorite;
    }

    #endregion
}