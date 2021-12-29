using Microsoft.JSInterop;

namespace MASA.Blazor.Pro.Global.JsRuntime
{
    public class CookieStorage
    {
        IJSRuntime _jsRuntime;

        public CookieStorage(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        const string GetCookieJs = "(function(name){const reg = new RegExp(`(^| )${name}=([^;]*)(;|$)`);const arr = document.cookie.match(reg);if (arr) {return unescape(arr[2]);}return null;})";

        const string SetCookieJs = "(function(name,value){document.cookie = `${name}=${escape(value.toString())};path=/;}`;})";

        public async Task<string> GetCookie(string key)
        {
            return await _jsRuntime.InvokeAsync<string>("eval", $"{GetCookieJs}('{key})'");
        }

        public async void SetItemAsync<T>(string key, T? value)
        {
            try
            {
                await _jsRuntime.InvokeVoidAsync("eval", $"{SetCookieJs}('{key}','{value}')");
            }
            catch
            {

            }
        }
    }
}
