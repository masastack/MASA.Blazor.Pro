using BlazorComponent.Components;
using MASA.Blazor.Pro.Global;
using System.Text.Json;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class I18nServiceCollectionExtensions
    {
        public static IServiceCollection AddI18n(this IServiceCollection services,string languageSettingFile)
        {
            var languageSettings= JsonSerializer.Deserialize<List<LanguageSetting>>(File.ReadAllText(languageSettingFile)) ?? throw new Exception("I18n Josn配置异常");
            services.AddSingleton(languageSettings);

            foreach (var seeting in languageSettings)
            {
                I18n.AddLang(seeting.Value, seeting.FilePath, seeting.IsDefaultLanguage);
            }
            services.AddScoped<I18n>();

            return services;
        }
    }
}
