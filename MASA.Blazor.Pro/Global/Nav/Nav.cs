namespace MASA.Blazor.Pro.Global
{
    public class NavCategory
    {
        public NavCategory(string category, Nav[] navs)
        {
            Category = category;
            Navs = navs;
        }

        public string Category { get; set; }

        public Nav[] Navs { get; set; }
    }

    public class Nav
    {
        public Nav(int id,string href, string icon, string title, Nav[]? childs)
        {
            Id = id;
            Href = href;
            Icon = icon;
            ParentIcon = icon;
            Title = title;
            FullTitle = title;
            Childs = childs;
        }

        public int Id { get; set; }

        public int ParentId { get; set; }

        public string? Href { get; set; }

        public string Icon { get; set; }

        public string ParentIcon { get; set; }

        public string Title { get; set; }

        public string FullTitle { get; set; }

        public bool Hide { get; set; }

        public bool Active { get; set; }

        public Nav[]? Childs { get; set; }
    }

    public class NavHelper
    {
        List<NavCategory> _navCategorys;

        NavigationManager _navigationManager;

        GlobalEvent _globalEvent;

        public List<Nav> Navs { get; }

        public List<Nav> SameLevelNavs { get; }

        public NavHelper(List<NavCategory> navCategorys, NavigationManager navigationManager, GlobalEvent globalEvent)
        {
            _navCategorys = navCategorys;
            _navigationManager= navigationManager;
            _globalEvent= globalEvent;
            Navs = new List<Nav>();
            SameLevelNavs=new List<Nav>();
            Initialization();
        }

        void Initialization()
        {
            foreach (var navCategory in _navCategorys)
            {
                foreach (var nav in navCategory.Navs)
                {
                    if (nav.Hide is false) Navs.Add(nav);

                    if (nav.Childs is not null)
                    {
                        nav.Childs = nav.Childs.Where(c => c.Hide is false).ToArray();

                        nav.Childs.ForEach(child =>
                        {
                            child.ParentId = nav.Id;
                            child.FullTitle = $"{nav.Title} {child.Title}";
                            child.ParentIcon = nav.Icon;
                        });
                    } 
                }
            }

            foreach (var nav in Navs)
            {
                SameLevelNavs.Add(nav);
                if (nav.Childs is not null) SameLevelNavs.AddRange(nav.Childs);
            }
        }

        public void NavigateTo(Nav nav)
        {
            Active(nav);
            _navigationManager.NavigateTo(nav.Href ?? "");
        }

        public void NavigateTo(string href)
        {
            var nav=SameLevelNavs.FirstOrDefault(n => n.Href == href);
            if(nav is not null) Active(nav);
            _navigationManager.NavigateTo(href);
        }

        public void RefreshRender(Nav nav)
        {
            Active(nav);
            _globalEvent.Excute();
        }

        public void NavigateToByEvent(Nav nav)
        {
            RefreshRender(nav);
            _navigationManager.NavigateTo(nav.Href ?? "");
        }

        public void Active(Nav nav)
        {
            SameLevelNavs.ForEach(n => n.Active = false);
            nav.Active = true;
        }
    }
}
