namespace MASA.Blazor.Pro.Global;

public class NavHelper
{
    private List<NavModel> _navList;
    private NavigationManager _navigationManager;
    private GlobalConfigChangedEvent _globalConfigChangedEvent;

    public List<NavModel> Navs { get; }

    public List<NavModel> SameLevelNavs { get; }

    public NavHelper(List<NavModel> navList, NavigationManager navigationManager, GlobalConfigChangedEvent globalEvent)
    {
        _navList = navList;
        _navigationManager = navigationManager;
        _globalConfigChangedEvent = globalEvent;
        Navs = new List<NavModel>();
        SameLevelNavs = new List<NavModel>();
        Initialization();
    }

    private void Initialization()
    {
        _navList.ForEach(nav =>
        {
            if (nav.Hide is false) Navs.Add(nav);

            if (nav.Children is not null)
            {
                nav.Children = nav.Children.Where(c => c.Hide is false).ToArray();

                nav.Children.ForEach(child =>
                {
                    child.ParentId = nav.Id;
                    child.FullTitle = $"{nav.Title} {child.Title}";
                    child.ParentIcon = nav.Icon;
                });
            }
        });

        Navs.ForEach(nav =>
        {
            SameLevelNavs.Add(nav);
            if (nav.Children is not null) SameLevelNavs.AddRange(nav.Children);
        });
    }

    public void NavigateTo(NavModel nav)
    {
        Active(nav);
        _navigationManager.NavigateTo(nav.Href ?? "");
    }

    public void NavigateTo(string href)
    {
        var nav = SameLevelNavs.FirstOrDefault(n => n.Href == href);
        if (nav is not null) Active(nav);
        _navigationManager.NavigateTo(href);
    }

    public void RefreshRender(NavModel nav)
    {
        Active(nav);
        _globalConfigChangedEvent.Invoke();
    }

    public void NavigateToByEvent(NavModel nav)
    {
        RefreshRender(nav);
        _navigationManager.NavigateTo(nav.Href ?? "");
    }

    public void Active(NavModel nav)
    {
        SameLevelNavs.ForEach(n => n.Active = false);
        nav.Active = true;
        if (nav.ParentId != 0) SameLevelNavs.First(n => n.Id == nav.ParentId).Active = true;
    }
}

