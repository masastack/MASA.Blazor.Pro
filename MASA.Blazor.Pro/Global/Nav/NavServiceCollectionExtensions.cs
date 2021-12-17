using MASA.Blazor.Pro.Global;
using System.Text.Json;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class NavServiceCollectionExtensions
    {
        public static IServiceCollection AddNav(this IServiceCollection services, string NavSettingsFile)
        {
            var navCategorys = JsonSerializer.Deserialize<List<NavCategory>>(File.ReadAllText(NavSettingsFile));
            if (navCategorys is null) throw new Exception("please config Navigation");
            var navs = navCategorys.SelectMany(nc => nc.Navs).ToList();
            foreach(var navCategory in navCategorys)
            {
                navCategory.Navs = navCategory.Navs.Where(n => n.Hide == false).ToArray();
                foreach (var nav in navs)
                {
                    if (nav.Childs is not null)
                    {
                        nav.Childs = nav.Childs.Where(child => child.Hide == false).ToArray();
                        nav.Childs.ForEach(child =>
                        {
                            child.ParentId = nav.Id;
                            child.FullTitle = $"{nav.Title} {child.Title}";
                            child.ParentIcon = nav.Icon;
                        });
                    }
                }
            }
            foreach (var nav in navs)
            {
                if (nav.Childs is not null)
                {
                    nav.Childs.ForEach(child =>
                    {
                        child.ParentId = nav.Id;
                        child.FullTitle = $"{nav.Title} {child.Title}";
                        child.ParentIcon = nav.Icon;
                    });
                }
            }
            services.AddSingleton(navCategorys);

            return services;
        }
    }
}
