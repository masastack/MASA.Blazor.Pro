namespace MASA.Blazor.Pro.Demo
{
    public class MultiRange
    {
        public MultiRange(RangeType rangeType, string text, double leftNumber, double rightNumber=0)
        {
            RangeType = rangeType;
            Text = text;
            LeftNumber = leftNumber;
            RightNumber = rightNumber;
        }

        public RangeType RangeType { get; set; }

        public string Text { get; set; }

        public double LeftNumber { get; set; }

        public double RightNumber { get; set; }
    }

    public enum RangeType
    {
        All,
        Less,
        LessEqual,
        More,
        MoreEqual,
        Range
    }
}
