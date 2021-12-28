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
            services.AddSingleton(navCategorys);
            services.AddScoped<NavHelper>();

            return services;
        }
    }
}
