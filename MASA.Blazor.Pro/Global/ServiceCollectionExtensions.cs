namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        static readonly string _basePath;
        static readonly string _languageConfigPath;
        static readonly string _navPath;
        static readonly string _languageConfigUri;
        static readonly string _navUri;

        static ServiceCollectionExtensions()
        {
            _basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new Exception("Get the assembly root directory exception!");
            _languageConfigUri = "i18nResources/config/languageConfig.json";
            _navUri = "nav/nav.json";
            _languageConfigPath = Path.Combine(_basePath, "wwwroot", _languageConfigUri);
            _navPath = Path.Combine(_basePath, "wwwroot", _navUri);
        }

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
            var languageConfig = await httpclient.GetFromJsonAsync<LanguageConfig>(_languageConfigUri) ?? throw new Exception("Failed to read i18n json file data!");
            services.AddSingleton(languageConfig);
            await services.AddMasaI18nForWasm(baseUri, languageConfig);
            var navCategorys = await httpclient.GetFromJsonAsync<List<NavCategory>>(_navUri) ?? throw new Exception("please config Navigation!");
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
