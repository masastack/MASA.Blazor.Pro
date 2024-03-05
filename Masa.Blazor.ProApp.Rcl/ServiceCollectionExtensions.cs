namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMasaBlazorPro(this IServiceCollection services)
    {
        services.AddMasaBlazor(options =>
        {
            options.ConfigureTheme(theme =>
            {
                theme.Themes.Light.Primary = "#4f33ff";
                theme.Themes.Light.Secondary = "#5e5c71";
                // theme.Themes.Light.Accent = "#006C4F";
                theme.Themes.Light.Error = "#BA1A1A";
                theme.Themes.Light.Surface = "#f0f3fa";
                theme.Themes.Light.OnSurface = "#1C1B1F";

                theme.Themes.Dark.Primary = "#C5C0FF";
                theme.Themes.Dark.Secondary = "#C7C4DC";
                // theme.Themes.Dark.Accent = "#67DBAF";
                theme.Themes.Dark.Error = "#FFB4AB";
                theme.Themes.Dark.Surface = "#131316";
                theme.Themes.Dark.OnPrimary = "#2400A2";
                theme.Themes.Dark.OnSecondary = "#302E42";
                theme.Themes.Dark.OnAccent = "#003827";
                theme.Themes.Dark.OnSurface = "#C9C5CA";
            });
        });

        return services;
    }
}