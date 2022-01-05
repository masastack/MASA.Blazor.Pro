namespace MASA.Blazor.Pro.Global;

public delegate void GlobalConfigChange();

public class GlobalEvent
{
    private event GlobalConfigChange? OnGloabConfigChange;

    public void AddEvent(GlobalConfigChange action)
    {
        OnGloabConfigChange += action;
    }

    public void RemoveEvent(GlobalConfigChange action)
    {
        OnGloabConfigChange -= action;
    }

    public void Excute()
    {
        OnGloabConfigChange?.Invoke();
    }
}

