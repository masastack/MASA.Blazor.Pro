using Microsoft.AspNetCore.Components.Forms;

namespace MASA.Blazor.Pro.Pages.Apps.Todo;

public partial class TodoDetail
{
    private readonly List<SelectData> _tagList = new()
    {
        new SelectData() { Label = "Team", Value = "Team" },
        new SelectData() { Label = "Low", Value = "Low" },
        new SelectData() { Label = "Medium", Value = "Medium" },
        new SelectData() { Label = "High", Value = "High" },
        new SelectData() { Label = "Update", Value = "Update" }
    };
    private readonly List<SelectData> _assigneeList = new()
    {
        new SelectData() { Label = "紫萱", Value = "紫萱" },
        new SelectData() { Label = "若芹", Value = "若芹" },
        new SelectData() { Label = "思菱", Value = "思菱" },
        new SelectData() { Label = "向秋", Value = "向秋" },
        new SelectData() { Label = "雨珍", Value = "雨珍" },
        new SelectData() { Label = "海瑶", Value = "海瑶" },
        new SelectData() { Label = "乐萱", Value = "乐萱" },
    };
    private MForm? _mForm;
    private bool _isEdit;
    private TodoData _selectData = new();

    private string CompletedColor { get { return _selectData.IsCompleted ? "text-capitalize neutral-lighten-5 neutral-lighten-2--text" : "theme--dark primary"; } }

    private string CompletedText { get { return _selectData.IsCompleted ? "Completed" : "Mark Complete"; } }

    [CascadingParameter]
    public TodoList TodoList { get; set; } = default!;

    [Parameter]
    public bool Value { get; set; }

    [Parameter]
    public TodoData? SelectItem { get; set; }

    [Parameter]
    public EventCallback<bool> ValueChanged { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;

    private async Task HideNavigationDrawer()
    {
        if (ValueChanged.HasDelegate)
        {
            await ValueChanged.InvokeAsync(false);
        }
    }

    private void Complete()
    {
        _selectData.IsCompleted = !_selectData.IsCompleted;
        _selectData.IsChecked = _selectData.IsCompleted;
    }

    private void HandleCloseClick(string lable)
    {
        _selectData.Tag.Remove(lable);
    }

    protected override async Task OnParametersSetAsync()
    {
        if (SelectItem == null)
        {
            SelectItem = new TodoData();
            _isEdit = false;
        }
        else
        {
            _isEdit = true;
        }

        _selectData = new TodoData
        {
            Id = SelectItem.Id,
            IsChecked = SelectItem.IsChecked,
            Assignee = SelectItem.Assignee,
            Avatar = SelectItem.Avatar,
            Description = SelectItem.Description,
            IsCompleted = SelectItem.IsCompleted,
            IsDeleted = SelectItem.IsDeleted,
            IsImportant = SelectItem.IsImportant,
            DueDate = SelectItem.DueDate,
            Title = SelectItem.Title
        };
        _selectData.Tag.AddRange(SelectItem.Tag);

        if (ValueChanged.HasDelegate && !Value && _mForm != null)
        {
            await _mForm.ResetValidationAsync();
        }
    }

    private async Task Add(EditContext context)
    {
        var success = context.Validate();
        if (success)
        {
            _selectData.Id = TodoService.List.Count + 1;
            TodoService.List.Insert(0, _selectData);
            await HideNavigationDrawer();

            NavigationManager.NavigateTo("apps/todo");
        }
    }

    private async Task Update(EditContext context)
    {
        var success = context.Validate();
        if (success)
        {
            var data = (TodoData)context.Model;
            TodoList.UpdateData(data);
            await HideNavigationDrawer();
        }
    }

    private async Task ResetAsync()
    {
        if (_mForm != null)
        {
            await _mForm.ResetValidationAsync();
        }

        if (SelectItem != null)
        {
            _selectData = new TodoData
            {
                Id = SelectItem.Id,
                IsChecked = SelectItem.IsChecked,
                Assignee = SelectItem.Assignee,
                Avatar = SelectItem.Avatar,
                Description = SelectItem.Description,
                IsCompleted = SelectItem.IsCompleted,
                IsDeleted = SelectItem.IsDeleted,
                IsImportant = SelectItem.IsImportant,
                DueDate = SelectItem.DueDate,
                Tag = SelectItem.Tag,
                Title = SelectItem.Title
            };
        }
    }

    private async Task DeleteTask()
    {
        _selectData.IsDeleted = true;
        TodoList.UpdateData(_selectData);
        await HideNavigationDrawer();
    }
}