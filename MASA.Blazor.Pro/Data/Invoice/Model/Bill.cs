namespace MASA.Blazor.Pro.Data;

public class Bill
{
    public string? Type { get; set; }

    public int Cost { get; set; }

    public int Qty { get; set; }

    public double Price { get; set; }

    public string? Remark { get; set; }

    public bool ShowMenu { get; set; }

    public string? Discount { get; set; }

    public int Tax1 { get; set; }

    public int Tax2 { get; set; }

    public void Bind(Bill input)
    {
        Type = input.Type;
        Cost = input.Cost;
        Qty = input.Qty;
        Price = input.Price;
        Remark = input.Remark;
    }
}

