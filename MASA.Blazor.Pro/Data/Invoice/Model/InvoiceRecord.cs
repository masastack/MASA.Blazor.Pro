using MASA.Blazor.Pro.Data.User;

namespace MASA.Blazor.Pro.Data.Invoice.Model;

public class InvoiceRecord
{
    public int Id { get; set; }
    public UserData Client { get; set; } = default!;
    public int Total { get; set; }
    public DateTime Date { get; set; }
    public int Balance { get; set; }
    public int State { get; set; }
}

