namespace MASA.Blazor.Pro.Data;

public class StateItem
{
    public string Label { get; set; }
    public int Value { get; set; }

    public StateItem(string label, int value)
    {
        Label = label;
        Value = value;
    }
}

