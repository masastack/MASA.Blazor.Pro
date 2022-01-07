namespace MASA.Blazor.Pro.Global.Config;
public class GlobalConfigChangedEvent
{
    public delegate void GlobalConfigChanged();
    public event GlobalConfigChanged? OnGlobalConfigChanged;

    public void Invoke()
    {
        OnGlobalConfigChanged?.Invoke();
    }
}
