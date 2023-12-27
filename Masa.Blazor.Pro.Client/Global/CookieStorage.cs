using Microsoft.JSInterop;

namespace Masa.Blazor.Pro;

public class CookieStorage
{
    private readonly IJSRuntime _jsRuntime;

    public CookieStorage(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<string> GetAsync(string key)
    {
        try
        {
            return await _jsRuntime.InvokeAsync<string>(JsInteropConstants.GetCookie, key);
        }
        catch (JSDisconnectedException)
        {
            // ignore
            return string.Empty;
        }
    }

    public async void SetAsync<T>(string key, T? value)
    {
        try
        {
            await _jsRuntime.InvokeVoidAsync(JsInteropConstants.SetCookie, key, value?.ToString());
        }
        catch (JSDisconnectedException)
        {
            // ignore
        }
    }
}
