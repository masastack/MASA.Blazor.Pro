﻿using MASA.Blazor.Pro.Global;

namespace MASA.Blazor.Pro.Middleware
{
    public class CookieMiddleware
    {
        private readonly RequestDelegate _next;

        public CookieMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, GlobalConfigs globalConfig)
        {
            var cookies = context.Request.Cookies;
            globalConfig.Initialization(cookies);

            await _next(context);
        }
    }
}
