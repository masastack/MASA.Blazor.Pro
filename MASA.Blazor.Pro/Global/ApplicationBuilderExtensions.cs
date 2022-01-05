namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseGlobal(this IApplicationBuilder app)
        {
            app.UseMiddleware<MASA.Blazor.Pro.Global.CookieMiddleware>();

            return app;
        }
    }
}
