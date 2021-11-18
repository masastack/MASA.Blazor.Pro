using MASA.Blazor.Pro.Global;
using System.Text.Json;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class I18nServiceCollectionExtensions
    {
        public static IServiceCollection AddI18n(this IServiceCollection services, string languageSettingsFile)
        {
            LanguageProvider.AddLang(languageSettingsFile);
            services.AddScoped<LanguageProvider>();

            return services;
        }
    }
}
