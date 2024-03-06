using Masa.Blazor.Pro.Components;
using Microsoft.Extensions.Logging;

namespace ProApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMasaBlazorPro();
            builder.Services.AddSingleton(_ = new ProDatabase(FileSystem.AppDataDirectory));

            builder.Services.AddLogging(logging =>
            {
                logging.AddFilter("Microsoft.AspNetCore.Components.WebView", LogLevel.Trace);
            });

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
