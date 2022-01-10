namespace MASA.Blazor.Pro.Pages.App.Todo;

public partial class TodoList
{
    private readonly Dictionary<string, string> _tagColorMap = TodoService.GetTagColorMap();
    private readonly string[] _avas = TodoService.GetAvatars();

    private TodoDto _selectItem = new();
    private string? _filterText;
    private bool _visible = false;
    private string? _inputText;
    private List<TodoDto> _thisList = new();
    private readonly List<TodoDto> _dataList = TodoService.GetList();

    [Parameter]
    public string? FilterText
    {
        get { return _filterText; }
        set
        {
            _filterText = value;
            _thisList = TodoService.GetFilterList(_filterText);
        }
    }

    private void ShowDetail(TodoDto item)
    {
        _visible = true;
        _selectItem = item;
    }

    private void ResetSort()
    {
        _thisList = _thisList.OrderBy(d => d.Id).ToList();
    }

    private void SortbyAssignee()
    {
        _thisList = _thisList.OrderBy(d => d.Assignee).ToList();
    }

    private void SortbyDueDate()
    {
        _thisList = _thisList.OrderBy(d => d.DueDate).ToList();
    }

    private void InputTextChanged(string? text)
    {
        if (!string.IsNullOrWhiteSpace(text))
            _thisList = _dataList.Where(item => item.Title.Contains(text)).ToList();
        else
            _thisList = _dataList;
    }

    public string? InputText
    {
        get { return _inputText; }
        set
        {
            _inputText = value;
            InputTextChanged(_inputText);
        }
    }

    public void UpdateData(TodoDto data)
    {
        var index = _dataList.FindIndex(d => d.Id == data.Id);
        _dataList[index] = data;

        FilterText = _filterText;
    }
}

