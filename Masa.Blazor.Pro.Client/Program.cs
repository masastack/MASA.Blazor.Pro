using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

await builder.Services.AddMasaBlazor(options =>
{
    options.ConfigureTheme(theme =>
    {
        theme.Themes.Light.Primary = "#4318FF";
        theme.Themes.Light.Accent = "#4318FF";
    });
}).AddI18nForWasmAsync($"{builder.HostEnvironment.BaseAddress}/i18n");

await builder.Services.AddGlobalForWasmAsync(builder.HostEnvironment.BaseAddress);

await builder.Build().RunAsync();
