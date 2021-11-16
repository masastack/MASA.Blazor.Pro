using Microsoft.JSInterop;
using System.Text.Json;

namespace MASA.Blazor.Pro.JsRuntime
{
    public class LocalStorage
    {
        IJSRuntime _jsRuntime;

        public LocalStorage(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task SetItemAsync(string key, object value)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, JsonSerializer.Serialize(value));
        }

        public async Task<T?> GetItemAsync<T>(string key)
        {
            var value = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);
            if (value is null) return default;
            return JsonSerializer.Deserialize<T>(value);
        }
    }
}
