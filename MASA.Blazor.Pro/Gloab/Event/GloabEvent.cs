namespace MASA.Blazor.Pro.Gloab
{
    public class GloabEvent
    {
        private event GloabConfigChange? OnGloabConfigChange;

        public void AddEvent(GloabConfigChange action)
        {
            OnGloabConfigChange += action;
        }

        public void Excute()
        {
            OnGloabConfigChange?.Invoke();
        }
    }

    public delegate void GloabConfigChange();
}
