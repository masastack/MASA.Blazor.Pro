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

        public string Href { get; set; }

        public string Icon { get; set; }

        public string ParentIcon { get; set; }

        public string Title { get; set; }

        public string FullTitle { get; set; }

        public bool Hide { get; set; }

        public Nav[]? Childs { get; set; }
    }
}
