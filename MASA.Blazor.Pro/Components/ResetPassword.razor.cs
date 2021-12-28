namespace MASA.Blazor.Pro.Components;

public partial class ResetPassword
{
    private bool _show;

    [Inject]
    public NavigationManager Navigation { get; set; } = default!;

    [Parameter]
    public bool HideLogo { get; set; }

    [Parameter]
    public double Width { get; set; } = 410;

    [Parameter]
    public StringNumber? Elevation { get; set; }

    [Parameter]
    public string SignInRoute { get; set; } = $"pages/authentication/login-v1";
}

