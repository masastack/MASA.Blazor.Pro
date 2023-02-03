using System.Globalization;

namespace Masa.Blazor.Pro.Global;

public class GlobalConfig
{
	#region Field

	private string? _pageMode;
	private bool _expandOnHover;
	private bool _navigationMini;
	private string? _favorite;
	private CookieStorage? _cookieStorage;
	private string? _navigationStyle;

	#endregion

	#region Property

	public static string PageModeKey { get; set; } = "GlobalConfig_PageMode";

	public static string NavigationStyleKey { get; set; } = "GlobalConfig_NavigationStyle";

	public static string NavigationMiniCookieKey { get; set; } = "GlobalConfig_NavigationMini";

	public static string ExpandOnHoverCookieKey { get; set; } = "GlobalConfig_ExpandOnHover";

	public static string FavoriteCookieKey { get; set; } = "GlobalConfig_Favorite";

	public string PageMode
	{
		get => _pageMode ?? PageModes.PageTab;
		set
		{
			_pageMode = value;
			_cookieStorage?.SetItemAsync(PageModeKey, value);
		}
	}

	public string NavigationStyle
	{
		get => _navigationStyle ?? NavigationStyles.Flat;
		set
		{
			_navigationStyle = value;
			_cookieStorage?.SetItemAsync(NavigationStyleKey, value);
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

	public GlobalConfig(CookieStorage cookieStorage, IHttpContextAccessor httpContextAccessor)
	{
		_cookieStorage = cookieStorage;
		if (httpContextAccessor.HttpContext is not null) Initialization(httpContextAccessor.HttpContext.Request.Cookies);
	}

	#region event

	public delegate void GlobalConfigChanged();

	#endregion

	#region Method

	public void Initialization(IRequestCookieCollection cookies)
	{
		_pageMode = cookies[PageModeKey];
		_navigationStyle = cookies[NavigationStyleKey];
		_navigationMini = Convert.ToBoolean(cookies[NavigationMiniCookieKey]);
		_expandOnHover = Convert.ToBoolean(cookies[ExpandOnHoverCookieKey]);
		_favorite = cookies[FavoriteCookieKey];
	}
	#endregion
}