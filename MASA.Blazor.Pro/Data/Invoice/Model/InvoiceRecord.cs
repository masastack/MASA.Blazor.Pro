using MASA.Blazor.Pro.Data.User;

namespace MASA.Blazor.Pro.Data.Invoice;

public class InvoiceRecord
{
    public InvoiceRecord(UserData client)
    {
        Client = client;
    }

    public int Id { get; set; }

    public UserData Client { get; set; }

    public int Total { get; set; }

    public DateOnly Date { get; set; } = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

    private DateOnly? _dueDate;
    public DateOnly DueDate 
    {
        get => (_dueDate ?? (_dueDate = Date.AddMonths(1).AddDays(2))).Value;
        set => _dueDate = value;
    } 

    public int Balance { get; set; }

    public int State { get; set; }
}

