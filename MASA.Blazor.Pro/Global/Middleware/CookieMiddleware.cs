namespace MASA.Blazor.Pro.Global;

public class CookieMiddleware
{
    private readonly RequestDelegate _next;

    public CookieMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, GlobalConfig globalConfig)
    {
        var cookies = context.Request.Cookies;
        globalConfig.Initialization(cookies);

        await _next(context);
    }
}