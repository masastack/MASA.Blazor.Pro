namespace MASA.Blazor.Pro.Gloab
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
        public Nav(string href, string icon, string title, Nav[]? childs)
        {
            Href = href;
            Icon = icon;
            Title = title;
            Childs = childs;
        }

        public string Href { get; set; }

        public string Icon { get; set; }

        public string Title { get; set; }

        public Nav[]? Childs { get; set; }
    }
}
