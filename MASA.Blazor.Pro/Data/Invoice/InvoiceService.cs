namespace MASA.Blazor.Pro.Data;

public static class InvoiceService
{
    public static List<InvoiceRecord> _invoiceRecords = new List<InvoiceRecord> {
        new InvoiceRecord(UserService.UserDatas[0]){Id=0, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 1},
        new InvoiceRecord(UserService.UserDatas[1]){Id=1, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 1},
        new InvoiceRecord(UserService.UserDatas[2]){Id=2, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 2},
        new InvoiceRecord(UserService.UserDatas[3]){Id=3, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 3},
        new InvoiceRecord(UserService.UserDatas[4]){Id=4, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 4},
        new InvoiceRecord(UserService.UserDatas[5]){Id=5, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 5},
        new InvoiceRecord(UserService.UserDatas[6]){Id=6, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 1},
        new InvoiceRecord(UserService.UserDatas[7]){Id=7, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 2},
        new InvoiceRecord(UserService.UserDatas[8]){Id=8, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 3},
        new InvoiceRecord(UserService.UserDatas[9]){Id=9, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 4},
        new InvoiceRecord(UserService.UserDatas[10]){Id=10, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 5},
        new InvoiceRecord(UserService.UserDatas[11]){Id=11, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 1},
        new InvoiceRecord(UserService.UserDatas[12]){Id=12, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 2},
        new InvoiceRecord(UserService.UserDatas[13]){Id=13, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 3},
        new InvoiceRecord(UserService.UserDatas[14]){Id=14, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 4},
        new InvoiceRecord(UserService.UserDatas[15]){Id=16, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 5},
        new InvoiceRecord(UserService.UserDatas[16]){Id=15, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 1},
        new InvoiceRecord(UserService.UserDatas[17]){Id=17, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 2},
        new InvoiceRecord(UserService.UserDatas[18]){Id=18, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 3},
        new InvoiceRecord(UserService.UserDatas[19]){Id=19, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 4},
        new InvoiceRecord(UserService.UserDatas[20]){Id=20, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 5},
        new InvoiceRecord(UserService.UserDatas[21]){Id=21, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 1},
        new InvoiceRecord(UserService.UserDatas[22]){Id=22, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 2},
        new InvoiceRecord(UserService.UserDatas[23]){Id=23, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 3},
        new InvoiceRecord(UserService.UserDatas[24]){Id=34, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 4},
        new InvoiceRecord(UserService.UserDatas[25]){Id=25, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 5},
        new InvoiceRecord(UserService.UserDatas[26]){Id=26, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 1},
        new InvoiceRecord(UserService.UserDatas[27]){Id=27, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 2},
        new InvoiceRecord(UserService.UserDatas[28]){Id=28, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 3},
        new InvoiceRecord(UserService.UserDatas[29]){Id=29, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 4},
        new InvoiceRecord(UserService.UserDatas[30]){Id=30, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 5},
        new InvoiceRecord(UserService.UserDatas[31]){Id=31, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 1},
        new InvoiceRecord(UserService.UserDatas[32]){Id=32, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 2},
        new InvoiceRecord(UserService.UserDatas[33]){Id=33, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 3},
        new InvoiceRecord(UserService.UserDatas[34]){Id=34, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 4},
        new InvoiceRecord(UserService.UserDatas[35]){Id=35, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 5},
        new InvoiceRecord(UserService.UserDatas[36]){Id=36, Balance = 205, Total=3171, Date = DateOnly.FromDateTime(DateTime.Now), State = 1}
    };

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

