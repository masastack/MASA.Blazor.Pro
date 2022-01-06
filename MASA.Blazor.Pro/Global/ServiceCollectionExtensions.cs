namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGlobalForServer(this IServiceCollection services)
        {     
            services.AddMasaI18nForServer("wwwroot/i18nResources");
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new Exception("Get the assembly root directory exception!");
            services.AddNav(Path.Combine(basePath, $"wwwroot/nav/nav.json"));
            services.AddScoped<GlobalConfigs>();
            services.AddScoped<GlobalEvent>();

            return services;
        }

        public static async Task<IServiceCollection> AddGlobalForWasm(this IServiceCollection services, string baseUri)
        {          
            await services.AddMasaI18nForWasmAsync(Path.Combine(baseUri, $"i18nResources"));
            using var httpclient = new HttpClient();
            var navCategorys = await httpclient.GetFromJsonAsync<List<NavCategory>>(Path.Combine(baseUri, $"nav/nav.json")) ?? throw new Exception("please config Navigation!");
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
            var globalConfigsParamter = new Dictionary<string, object?> { [nameof(GlobalConfigs)] = globalConfigs };

            return ParameterView.FromDictionary(globalConfigsParamter);
        }

    }
}
