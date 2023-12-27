using System.Globalization;

namespace Masa.Blazor.Pro.Global;

public class GlobalConfig
{
    private readonly I18n _i18n;
    private readonly CookieStorage _cookieStorage;

    private string? _pageMode;
    private bool _expandOnHover;
    private string? _favorite;
    private string? _navigationStyle;

    public GlobalConfig(CookieStorage cookieStorage, I18n i18n)
    {
        _i18n = i18n;
        _cookieStorage = cookieStorage;
    }

    public static string PageModeKey => "GlobalConfig_PageMode";

    public static string NavigationStyleKey => "GlobalConfig_NavigationStyle";

    public static string ExpandOnHoverCookieKey => "GlobalConfig_ExpandOnHover";

    public static string FavoriteCookieKey => "GlobalConfig_Favorite";

    public static string LangCookieKey => "GlobalConfig_Lang";

    public EventHandler? NavigationStyleChanged { get; set; }

    public EventHandler? PageModeChanged { get; set; }

    public EventHandler? ExpandOnHoverChanged { get; set; }

    public string PageMode
    {
        get => _pageMode ?? PageModes.PageTab;
        set
        {
            _pageMode = value;
            PageModeChanged?.Invoke(this, EventArgs.Empty);
            _cookieStorage.SetAsync(PageModeKey, value);
        }
    }

    public string NavigationStyle
    {
        get => _navigationStyle ?? NavigationStyles.Flat;
        set
        {
            _navigationStyle = value;
            NavigationStyleChanged?.Invoke(this, EventArgs.Empty);
            _cookieStorage.SetAsync(NavigationStyleKey, value);
        }
    }

    public bool ExpandOnHover
    {
        get => _expandOnHover;
        set
        {
            _expandOnHover = value;
            ExpandOnHoverChanged?.Invoke(this, EventArgs.Empty);
            _cookieStorage.SetAsync(ExpandOnHoverCookieKey, value);
        }
    }

    public string? Favorite
    {
        get => _favorite;
        set
        {
            _favorite = value;
            _cookieStorage.SetAsync(FavoriteCookieKey, value);
        }
    }

    public CultureInfo Culture
    {
        get => _i18n.Culture;
        set
        {
            _cookieStorage.SetAsync(LangCookieKey, value.Name);
            _i18n.SetCulture(value);
        }
    }

    public async Task InitFromStorage()
    {
        PageMode = await _cookieStorage.GetAsync(PageModeKey);
        NavigationStyle = await _cookieStorage.GetAsync(NavigationStyleKey);
        ExpandOnHover = Convert.ToBoolean(await _cookieStorage.GetAsync(ExpandOnHoverCookieKey));
        Favorite = await _cookieStorage.GetAsync(FavoriteCookieKey);

        var lang = await _cookieStorage.GetAsync(LangCookieKey);
        if (!string.IsNullOrWhiteSpace(lang))
        {
            _i18n.SetCulture(new CultureInfo(lang));
        }
    }
}
