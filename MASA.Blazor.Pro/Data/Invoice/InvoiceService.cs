using MASA.Blazor.Pro.Data.Invoice.Model;
using MASA.Blazor.Pro.Data.User;

namespace MASA.Blazor.Pro.Data.Invoice;

public static class InvoiceService
{
    public static List<InvoiceRecord> _invoiceRecords = new List<InvoiceRecord> {
        new InvoiceRecord{Id=0, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 1, Client = UserService.UserDatas[0] },
        new InvoiceRecord{Id=1, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 1, Client = UserService.UserDatas[1] },
        new InvoiceRecord{Id=2, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 2, Client = UserService.UserDatas[2] },
        new InvoiceRecord{Id=3, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 3, Client = UserService.UserDatas[3] },
        new InvoiceRecord{Id=4, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 4, Client = UserService.UserDatas[4] },
        new InvoiceRecord{Id=5, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 5, Client = UserService.UserDatas[5] },
        new InvoiceRecord{Id=6, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 1, Client = UserService.UserDatas[6] },
        new InvoiceRecord{Id=7, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 2, Client = UserService.UserDatas[7] },
        new InvoiceRecord{Id=8, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 3, Client = UserService.UserDatas[8] },
        new InvoiceRecord{Id=9, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 4, Client = UserService.UserDatas[9] },
        new InvoiceRecord{Id=10, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 5, Client = UserService.UserDatas[10] },
        new InvoiceRecord{Id=11, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 1, Client = UserService.UserDatas[11] },
        new InvoiceRecord{Id=12, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 2, Client = UserService.UserDatas[12] },
        new InvoiceRecord{Id=13, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 3, Client = UserService.UserDatas[13] },
        new InvoiceRecord{Id=14, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 4, Client = UserService.UserDatas[14] },
        new InvoiceRecord{Id=16, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 5, Client = UserService.UserDatas[15] },
        new InvoiceRecord{Id=15, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 1, Client = UserService.UserDatas[16] },
        new InvoiceRecord{Id=17, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 2, Client = UserService.UserDatas[17] },
        new InvoiceRecord{Id=18, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 3, Client = UserService.UserDatas[18] },
        new InvoiceRecord{Id=19, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 4, Client = UserService.UserDatas[19] },
        new InvoiceRecord{Id=20, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 5, Client = UserService.UserDatas[20] },
        new InvoiceRecord{Id=21, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 1, Client = UserService.UserDatas[21] },
        new InvoiceRecord{Id=22, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 2, Client = UserService.UserDatas[22] },
        new InvoiceRecord{Id=23, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 3, Client = UserService.UserDatas[23] },
        new InvoiceRecord{Id=34, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 4, Client = UserService.UserDatas[24] },
        new InvoiceRecord{Id=25, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 5, Client = UserService.UserDatas[25] },
        new InvoiceRecord{Id=26, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 1, Client = UserService.UserDatas[26] },
        new InvoiceRecord{Id=27, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 2, Client = UserService.UserDatas[27] },
        new InvoiceRecord{Id=28, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 3, Client = UserService.UserDatas[28] },
        new InvoiceRecord{Id=29, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 4, Client = UserService.UserDatas[29] },
        new InvoiceRecord{Id=30, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 5, Client = UserService.UserDatas[30] },
        new InvoiceRecord{Id=31, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 1, Client = UserService.UserDatas[31] },
        new InvoiceRecord{Id=32, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 2, Client = UserService.UserDatas[32] },
        new InvoiceRecord{Id=33, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 3, Client = UserService.UserDatas[33] },
        new InvoiceRecord{Id=34, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 4, Client = UserService.UserDatas[34] },
        new InvoiceRecord{Id=35, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 5, Client = UserService.UserDatas[35] },
        new InvoiceRecord{Id=36, Balance = 205, Total=3171, Date = ConvertToDateOnly(DateTime.Now), State = 1, Client = UserService.UserDatas[36] }
    };

    public static DateOnly ConvertToDateOnly(DateTime dateTime)
    {
        return new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
    }

    public static List<Bill> Bills => new List<Bill>
    {
        new Bill{Type="App Design",Cost=24,Qty=1,Price=24,Remark="Designed UI kit & app pages."},
        new Bill{Type="App Customization",Cost=26,Qty=1,Price=26,Remark="Customization & Bug Fixes."},
        new Bill{Type="ABC Template",Cost=28,Qty=1,Price=28,Remark="Bootstrap 4 admin template."},
        new Bill{Type="App Development",Cost=32,Qty=1,Price=32,Remark="Native App Development."},
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
        var items = _invoiceRecords.Where(a => a.State == state || state == 0)
            .OrderBy(a => a.Id).Skip((pageIndex - 1) * pageSize)
            .Take(pageSize).ToList();
        return new PagingData<InvoiceRecord>(pageIndex, pageSize, _invoiceRecords.Count, items);
    }
}

