// @pb-anchor source=d_productsearch.srd kind=datawindow-codebehind
using Microsoft.AspNetCore.Components;
using MudBlazor;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Blazor.Services;

namespace ProductCatalog.Blazor.Components.DataWindows;

public partial class Productsearch : ComponentBase
{
    [Inject] private ProductsearchService _svc { get; set; } = default!;

    // GOLD RULE: row click/double-click — parent page wires these to navigate to detail
    [Parameter] public EventCallback<ProductsearchDto> OnRowSelected { get; set; }
    [Parameter] public EventCallback<ProductsearchDto> OnRowDoubleClicked { get; set; }

    internal IReadOnlyList<ProductsearchDto> _rows = Array.Empty<ProductsearchDto>();
    internal bool _loading;

    private ProductsearchDto? _lastClickedItem;
    private DateTime _lastClickTime = DateTime.MinValue;
    private static readonly TimeSpan DoubleClickThreshold = TimeSpan.FromMilliseconds(400);

    protected override Task OnInitializedAsync() => Task.CompletedTask;

    public async Task RetrieveAsync(string keyword, CancellationToken ct = default)
    {
        _loading = true;
        try
        {
            _rows = await _svc.SearchAsync(keyword, ct);
        }
        finally
        {
            _loading = false;
            StateHasChanged();
        }
    }

    internal async Task OnRowClick(DataGridRowClickEventArgs<ProductsearchDto> args)
    {
        var item = args.Item;
        var now = DateTime.UtcNow;
        var isDoubleClick = _lastClickedItem?.ProductitemsId == item?.ProductitemsId
                            && (now - _lastClickTime) <= DoubleClickThreshold;
        _lastClickedItem = item;
        _lastClickTime = now;

        if (isDoubleClick)
        {
            if (OnRowDoubleClicked.HasDelegate && item is not null)
                await OnRowDoubleClicked.InvokeAsync(item);
        }
        else
        {
            if (OnRowSelected.HasDelegate && item is not null)
                await OnRowSelected.InvokeAsync(item);
        }
    }
}
