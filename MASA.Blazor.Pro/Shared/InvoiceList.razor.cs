namespace MASA.Blazor.Pro.Shared;

public partial class InvoiceList
{
    private int _page = 1;
    private int _itemsPerPage = 10;
    private int _state = 0;
    private string _search = "";
    private List<int> _pageSizes = new List<int> { 10, 25, 50, 100 };

    private List<DataTableHeader<InvoiceRecordDto>> _headers = new List<DataTableHeader<InvoiceRecordDto>>
    {
        new (){ Text="#" , Value= nameof(InvoiceRecordDto.Id)},
        new (){ Text="Client" , Value= nameof(InvoiceRecordDto.Client)},
        new (){ Text="State" , Value= nameof(InvoiceRecordDto.State)},
        new (){ Text="Total" , Value= nameof(InvoiceRecordDto.Total)},
        new (){ Text="Issued Date" , Value= nameof(InvoiceRecordDto.Date)},
        new (){ Text="Balance" , Value= nameof(InvoiceRecordDto.Balance)},
        new (){ Text="Actions" , Value = "Action", Sortable = false},
    };

    private List<InvoiceStateDto> _stateItems = InvoiceService.GetStateList();

    private PagingData<InvoiceRecordDto> _records = new(0, 0, 0, Enumerable.Empty<InvoiceRecordDto>());

    private PagingData<InvoiceRecordDto> LoadPagingData() => InvoiceService.GetInvoiceRecordList(_page, _itemsPerPage, _state);

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

    private void NavigateToPreview(int id)
    {
        NavigationManager.NavigateTo($"apps/invoice/preview/{id}");
    }

    private void NavigateToEdit(int id)
    {
        NavigationManager.NavigateTo($"apps/invoice/edit/{id}");
    }

    private void NavigateToAdd()
    {
        NavigationManager.NavigateTo($"apps/invoice/add");
    }
}

