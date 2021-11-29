using MASA.Blazor.Pro.Data.Invoice.Model;

namespace MASA.Blazor.Pro.Data.Invoice;

public static class InvoiceService
{
    private static List<InvoiceRecord> _invoiceRecords = new List<InvoiceRecord> {
        new InvoiceRecord{Id=1, Balance = 205, Total=3171, Date = DateTime.Now, State = 1, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="./img/avatar/avatar-s-11.jpg" } },
        new InvoiceRecord{Id=2, Balance = 205, Total=3171, Date = DateTime.Now, State = 2, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="./img/avatar/avatar-s-20.jpg" } },
        new InvoiceRecord{Id=3, Balance = 205, Total=3171, Date = DateTime.Now, State = 3, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="./img/avatar/avatar-s-6.jpg" } },
        new InvoiceRecord{Id=4, Balance = 205, Total=3171, Date = DateTime.Now, State = 4, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=5, Balance = 205, Total=3171, Date = DateTime.Now, State = 5, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="./img/avatar/avatar-s-7.jpg" } },
        new InvoiceRecord{Id=6, Balance = 205, Total=3171, Date = DateTime.Now, State = 1, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=7, Balance = 205, Total=3171, Date = DateTime.Now, State = 2, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=8, Balance = 205, Total=3171, Date = DateTime.Now, State = 3, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="./img/avatar/avatar-s-8.jpg" } },
        new InvoiceRecord{Id=9, Balance = 205, Total=3171, Date = DateTime.Now, State = 4, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=10, Balance = 205, Total=3171, Date = DateTime.Now, State = 5, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=11, Balance = 205, Total=3171, Date = DateTime.Now, State = 1, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=12, Balance = 205, Total=3171, Date = DateTime.Now, State = 2, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="./img/avatar/avatar-s-9.jpg" } },
        new InvoiceRecord{Id=13, Balance = 205, Total=3171, Date = DateTime.Now, State = 3, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=14, Balance = 205, Total=3171, Date = DateTime.Now, State = 4, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=16, Balance = 205, Total=3171, Date = DateTime.Now, State = 5, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=15, Balance = 205, Total=3171, Date = DateTime.Now, State = 1, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=17, Balance = 205, Total=3171, Date = DateTime.Now, State = 2, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=18, Balance = 205, Total=3171, Date = DateTime.Now, State = 3, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=19, Balance = 205, Total=3171, Date = DateTime.Now, State = 4, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=20, Balance = 205, Total=3171, Date = DateTime.Now, State = 5, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=21, Balance = 205, Total=3171, Date = DateTime.Now, State = 1, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=22, Balance = 205, Total=3171, Date = DateTime.Now, State = 2, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=23, Balance = 205, Total=3171, Date = DateTime.Now, State = 3, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=34, Balance = 205, Total=3171, Date = DateTime.Now, State = 4, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=25, Balance = 205, Total=3171, Date = DateTime.Now, State = 5, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=26, Balance = 205, Total=3171, Date = DateTime.Now, State = 1, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=27, Balance = 205, Total=3171, Date = DateTime.Now, State = 2, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=28, Balance = 205, Total=3171, Date = DateTime.Now, State = 3, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=29, Balance = 205, Total=3171, Date = DateTime.Now, State = 4, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=30, Balance = 205, Total=3171, Date = DateTime.Now, State = 5, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=31, Balance = 205, Total=3171, Date = DateTime.Now, State = 1, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=32, Balance = 205, Total=3171, Date = DateTime.Now, State = 2, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=33, Balance = 205, Total=3171, Date = DateTime.Now, State = 3, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=34, Balance = 205, Total=3171, Date = DateTime.Now, State = 4, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=35, Balance = 205, Total=3171, Date = DateTime.Now, State = 5, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } },
        new InvoiceRecord{Id=36, Balance = 205, Total=3171, Date = DateTime.Now, State = 1, Client = new User.UserData{ Email="pwillis@cross.org",FullName="Andrew Burns",HeadImg="" } }
    };

    public static List<StateItem> GetStateItems()
    {
        return new List<StateItem>() {
            new StateItem("Downloaded", 1),
            new StateItem("Draft", 2),
            new StateItem("Paid", 3),
            new StateItem("Partial Payment", 4),
            new StateItem("Past Due", 5)
        };
    }

    public static PagingData<InvoiceRecord> GetInvoiceRecords(int pageIndex, int pageSize, int state, string search)
    {
        var items = _invoiceRecords.OrderBy(a => a.Id).Skip((pageIndex - 1) * pageSize)
            .Take(pageSize).ToList();
        return new PagingData<InvoiceRecord>(pageIndex, pageSize, _invoiceRecords.Count, items);
    }
}

