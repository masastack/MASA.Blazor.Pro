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
        builder.AddAttribute(2, "ChildContent", (RenderFragment)(sb =>
        {
            sb.OpenComponent(0, typeof(MIcon));
            sb.AddAttribute(1, "Icon", (Icon)"mdi-circle");
            sb.AddAttribute(2, "Color", tag.Color);
            sb.CloseComponent();
        }));
        builder.CloseComponent();

        builder.OpenComponent<MListItemContent>(3);
        builder.AddAttribute(4, "ChildContent", (RenderFragment)(sb =>
        {
            sb.OpenComponent<MListItemTitle>(0);
            sb.AddAttribute(1, "ChildContent", (RenderFragment)(c => c.AddContent(0, tag.Name)));
            sb.CloseComponent();
        }));
        builder.CloseComponent();
    };

    public static RenderFragment GenTagChips(
        IEnumerable<TodoTag> allTags,
        int[] shownTagIds,
        bool small = false,
        bool xSmall = false) => builder =>
    {
        foreach (var tag in allTags)
        {
            if (!shownTagIds.Contains(tag.Id)) continue;

            builder.OpenRegion(tag.GetHashCode());
            builder.OpenComponent(0, typeof(MChip));
            builder.AddAttribute(1, "Color", tag.Color);
            builder.AddAttribute(2, "Dark", true);
            builder.AddAttribute(3, "Small", small);
            builder.AddAttribute(4, "XSmall", xSmall);
            builder.AddAttribute(5, "Label", true);
            builder.AddAttribute(6, "Class", "mr-1");
            builder.AddAttribute(7, "ChildContent", (RenderFragment)(sb => { sb.AddContent(0, tag.Name); }));
            builder.CloseComponent();
            builder.CloseRegion();
        }
    };
}