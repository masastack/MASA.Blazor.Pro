namespace MASA.Blazor.Pro.Pages.App.Todo;

public partial class TodoList
{
    private readonly Dictionary<string, string> _chipTextColor = new()
    {
        { "Team", "pry" },
        { "Low", "sample-green" },
        { "Medium", "remind" },
        { "High", "error" },
        { "Update", "info" },
    };
    private readonly string[] _avas = new string[]
    {
        "/img/avatar/3-small.png",
        "/img/avatar/11-small.png",
        "/img/avatar/avatar-s-6.jpg",
        "/img/avatar/avatar-s-7.jpg",
        "/img/avatar/avatar-s-8.jpg",
        "/img/avatar/avatar-s-9.jpg"
    };
    private TodoDto _selectItem = new();
    private string? _filterText;
    private bool _visible = false;
    private string? _inputText;
    private List<TodoDto> _thisList = new();
    private readonly List<TodoDto> _dataList = TodoService.List;

    [Parameter]
    public string? FilterText
    {
        get { return _filterText; }
        set
        {
            _filterText = value;
            _thisList = _filterText switch
            {
                "important" => _dataList.Where(item => item.IsImportant && !item.IsDeleted).ToList(),
                "completed" => _dataList.Where(item => item.IsCompleted && !item.IsDeleted).ToList(),
                "deleted" => _dataList.Where(item => item.IsDeleted).ToList(),
                "team" => _dataList.Where(item => item.Tag.Contains("Team")).ToList(),
                "low" => _dataList.Where(item => item.Tag.Contains("Low")).ToList(),
                "medium" => _dataList.Where(item => item.Tag.Contains("Medium")).ToList(),
                "high" => _dataList.Where(item => item.Tag.Contains("High")).ToList(),
                "update" => _dataList.Where(item => item.Tag.Contains("Update")).ToList(),
                _ => _dataList.Where(item => !item.IsDeleted).ToList(),
            };
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

    public void AddData(TodoDto data)
    {
        _dataList.Insert(0, data);
    }
}

public class SelectData
{
    public string Label { get; set; } = default!;

    public string Value { get; set; } = default!;
}

