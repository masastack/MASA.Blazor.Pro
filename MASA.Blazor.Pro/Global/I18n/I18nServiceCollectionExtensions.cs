using MASA.Blazor.Pro.Global;
using System.Text.Json;
using System.Text;
using BlazorComponent.Components;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class I18nServiceCollectionExtensions
    {
        public static IServiceCollection AddI18n(this IServiceCollection services, string languageSettingsFile)
        {
            I18n.AddLang(languageSettingsFile);
            services.AddScoped<I18n>();

            return services;
        }
    }
}
