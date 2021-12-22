namespace MASA.Blazor.Pro.Demo;

public partial class TodoList
{
    
    private readonly Dictionary<string, string> _chipTextColor = new()
    {
        { "Team", "purple" },
        { "Low", "teal" },
        { "Medium", "orange" },
        { "High", "red" },
        { "Update", "cyan" },
    };
    private readonly Dictionary<string, string> _chipColor = new()
    {
        { "Team", "purple lighten-4" },
        { "Low", "teal lighten-4" },
        { "Medium", "orange lighten-4" },
        { "High", "red lighten-4" },
        { "Update", "cyan lighten-4" },
    };
    private readonly string[] _avas = new string[]
    {
        "https://pixinvent.com/demo/vuexy-vuejs-admin-dashboard-template/demo-1/img/5.f13458cc.png",
        "https://pixinvent.com/demo/vuexy-vuejs-admin-dashboard-template/demo-1/img/1.9cba4a79.png",
        "https://pixinvent.com/demo/vuexy-vuejs-admin-dashboard-template/demo-1/img/13-small.d796bffd.png",
        "https://pixinvent.com/demo/vuexy-vuejs-admin-dashboard-template/demo-1/img/12.03bf9466.png",
        "https://cdn.vuetifyjs.com/images/lists/4.jpg"
    };
    private TodoData _selectItem = new();
    private string? _filterText;
    private bool _visible = false;
    private string? _inputText;
    private List<TodoData> _thisList = new();
    private readonly List<TodoData> _dataList = TodoService.List;

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

    private void ShowDetail(TodoData item)
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

    public void UpdateData(TodoData data)
    {
        var index = _dataList.FindIndex(d => d.Id == data.Id);
        _dataList[index] = data;

        FilterText = _filterText;
    }

    public void AddData(TodoData data)
    {
        _dataList.Insert(0, data);
    }
}

public class SelectData
{
    public string Label { get; set; } = default!;

    public string Value { get; set; } = default!;
}

