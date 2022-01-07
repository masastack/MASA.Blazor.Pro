namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGlobalForServer(this IServiceCollection services)
        {     
            services.AddMasaI18nForServer("wwwroot/i18n");
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new Exception("Get the assembly root directory exception!");
            services.AddNav(Path.Combine(basePath, $"wwwroot/nav/nav.json"));
            services.AddScoped<GlobalConfig>();
            services.AddScoped<GlobalConfigChangedEvent>();

            return services;
        }

        public static async Task<IServiceCollection> AddGlobalForWasm(this IServiceCollection services, string baseUri)
        {          
            await services.AddMasaI18nForWasmAsync(Path.Combine(baseUri, $"i18n"));
            using var httpclient = new HttpClient();
            var navList = await httpclient.GetFromJsonAsync<List<NavModel>>(Path.Combine(baseUri, $"nav/nav.json")) ?? throw new Exception("please configure the Navigation!");
            services.AddNav(navList);
            services.AddScoped<GlobalConfig>();
            services.AddScoped<GlobalConfigChangedEvent>();

            return services;
        }
    }
}
