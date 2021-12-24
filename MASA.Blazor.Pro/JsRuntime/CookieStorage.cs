using Microsoft.JSInterop;
using System.Text.Json;

namespace MASA.Blazor.Pro.JsRuntime
{
    public class CookieStorage
    {
        IJSRuntime _jsRuntime;

        public CookieStorage(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async void SetItemAsync<T>(string key, T? value)
        {
            try 
            {
                await _jsRuntime.InvokeVoidAsync("cookieStore.set", key, value);
            }
            catch
            {

            }
        }
    }
}
