using MASA.Blazor.Pro.Global;
using System.Text.Json;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        static readonly string _languageConfigPath = "Data/I18nResources/config/languageConfig.json";
        static readonly string _navPath = "Data/Nav/nav.json";

        public static IServiceCollection AddGlobalForServer(this IServiceCollection services)
        {
            var languageConfig = JsonSerializer.Deserialize<LanguageConfig>(File.ReadAllText(_languageConfigPath)) ?? throw new Exception("Failed to read i18n json file data!");
            services.AddSingleton(languageConfig);
            services.AddMasaI18nForServer(languageConfig);
            services.AddNav(_navPath);
            services.AddScoped<GlobalConfigs>();
            services.AddScoped<GlobalEvent>();

            return services;
        }

        public static async Task<IServiceCollection> AddGlobalForWasm(this IServiceCollection services, string baseUri)
        {
            using var httpclient = new HttpClient();
            httpclient.BaseAddress = new Uri(baseUri);
            var languageConfig = await httpclient.GetFromJsonAsync<LanguageConfig>(File.ReadAllText(_languageConfigPath)) ?? throw new Exception("Failed to read i18n json file data!");
            services.AddSingleton(languageConfig);
            await services.AddMasaI18nForWasm(baseUri, languageConfig);
            var navCategorys = await httpclient.GetFromJsonAsync<List<NavCategory>>(File.ReadAllText(_navPath)) ?? throw new Exception("please config Navigation!");
            services.AddNav(navCategorys);
            services.AddScoped<GlobalConfigs>();
            services.AddScoped<GlobalEvent>();

            return services;
        }

        public static async Task<ParameterView> GetParameter(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var globalConfigs = provider.GetRequiredService<GlobalConfigs>();
            await globalConfigs.Initialization();
            var i18nParamter = (await services.GetMasaI18nParameter()).ToDictionary();
            var globalConfigsParamter = new Dictionary<string, object?> { [nameof(GlobalConfigs)] = globalConfigs };
            foreach (var (key, value) in i18nParamter)
            {
                globalConfigsParamter.Add(key, value);
            }

            return ParameterView.FromDictionary(globalConfigsParamter);
        }

    }
}
