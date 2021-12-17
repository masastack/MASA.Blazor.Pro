namespace MASA.Blazor.Pro.Components;

public partial class InvoiceList
{
    private int _page = 1;
    private int _itemsPerPage = 10;
    private int _state = 0;
    private string _search = "";
    private List<int> _pageSizes = new List<int> { 10, 25, 50, 100 };

    private List<DataTableHeader<InvoiceRecord>> _headers = new List<DataTableHeader<InvoiceRecord>>
    {
        new (){ Text="#" , Value= nameof(InvoiceRecord.Id)},
        new (){ Text="Client" , Value= nameof(InvoiceRecord.Client)},
        new (){ Text="State" , Value= nameof(InvoiceRecord.State)},
        new (){ Text="Total" , Value= nameof(InvoiceRecord.Total)},
        new (){ Text="Issued Date" , Value= nameof(InvoiceRecord.Date)},
        new (){ Text="Balance" , Value= nameof(InvoiceRecord.Balance)},
        new (){ Text="Actions" , Value = "Action", Sortable = false},
    };

    List<StateItem> _stateItems = InvoiceService.GetStateItems();

    PagingData<InvoiceRecord> _records = new(0, 0, 0, Enumerable.Empty<InvoiceRecord>());

    private PagingData<InvoiceRecord> LoadPagingData() => InvoiceService.GetInvoiceRecords(_page, _itemsPerPage, _state, _search);

    protected override Task OnInitializedAsync()
    {
        _records = LoadPagingData();
        return base.OnInitializedAsync();
    }

    private void SearchCHanged()
    {
        _records = LoadPagingData();
    }

    private void PaginationChanged()
    {
        _records = LoadPagingData();
    }

    private void PageSizeChanged(int pageSize)
    {
        _page = 1;
        _itemsPerPage = pageSize;
        _records = LoadPagingData();
    }

    private void StateChanged(int state)
    {
        _page = 1;
        _state = state;
        _records = LoadPagingData();
    }

    void NavigateToPreview(int id)
    {
        NavigationManager.NavigateTo($"apps/invoice/preview/{id}");
    }

    void NavigateToEdit(int id)
    {
        NavigationManager.NavigateTo($"apps/invoice/edit/{id}");
    }

    void NavigateToAdd()
    {
        NavigationManager.NavigateTo($"apps/invoice/add");
    }
}

