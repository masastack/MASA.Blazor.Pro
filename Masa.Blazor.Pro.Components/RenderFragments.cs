using BlazorComponent;
using Masa.Blazor.Pro.Components.Models;
using Microsoft.AspNetCore.Components;

namespace Masa.Blazor.Pro.Components;

public static class RenderFragments
{
    public static RenderFragment GenTagItem(TodoTag tag) => builder =>
    {
        builder.OpenComponent(0, typeof(MListItemIcon));
        builder.AddAttribute(1, "Class", "mr-4");
        builder.AddAttribute(2, "ChildContent", (RenderFragment)(sub =>
        {
            sub.OpenComponent(0, typeof(MIcon));
            sub.AddAttribute(1, "Icon", (Icon)"mdi-circle");
            sub.AddAttribute(2, "Color", tag.Color);
            sub.CloseComponent();
        }));
        builder.CloseComponent();

        builder.OpenComponent<MListItemContent>(3);
        builder.AddAttribute(4, "ChildContent", (RenderFragment)(sub =>
        {
            sub.OpenComponent<MListItemTitle>(0);
            sub.AddAttribute(1, "ChildContent", (RenderFragment)(c => c.AddContent(0, tag.Name)));
            sub.CloseComponent();
        }));
        builder.CloseComponent();
    };
}