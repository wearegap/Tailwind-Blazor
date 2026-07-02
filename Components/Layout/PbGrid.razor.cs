namespace ProductCatalog.Blazor.Components.Layout;

using Microsoft.AspNetCore.Components;

public partial class PbGrid<TItem>
{
    [Parameter] public IEnumerable<TItem>? Items { get; set; }
    [Parameter] public List<PbGridColumn<TItem>> Columns { get; set; } = new();
    [Parameter] public EventCallback<TItem> OnRowSelected { get; set; }
    [Parameter] public Func<TItem, bool>? IsRowDeleted { get; set; }
}
