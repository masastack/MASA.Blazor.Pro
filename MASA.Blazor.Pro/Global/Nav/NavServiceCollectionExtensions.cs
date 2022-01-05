using MASA.Blazor.Pro.Global;
using System.Text.Json;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class NavServiceCollectionExtensions
    {
        public static IServiceCollection AddNav(this IServiceCollection services, List<NavCategory> navCategorys)
        {
            services.AddSingleton(navCategorys);
            services.AddScoped<NavHelper>();

            return services;
        }

        public static IServiceCollection AddNav(this IServiceCollection services, string navSettingsFile)
        {
            var navCategorys = JsonSerializer.Deserialize<List<NavCategory>>(File.ReadAllText(navSettingsFile));
            if (navCategorys is null) throw new Exception("please config Navigation!");
            services.AddNav(navCategorys);

            return services;
        }
    }
}
