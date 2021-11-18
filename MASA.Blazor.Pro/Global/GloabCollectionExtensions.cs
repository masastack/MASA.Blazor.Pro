using MASA.Blazor.Pro.Global;
using System.Text.Json;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class GloabCollectionExtensions
    {
        public static IServiceCollection AddGlobal(this IServiceCollection services)
        {
            services.AddI18n("Data/I18nResources/languageSettings.json");
            services.AddNav("Data/Nav/nav.json");
            services.AddScoped<GlobalConfigs>();

            return services;
        }
    }
}
