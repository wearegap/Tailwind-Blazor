// @pb-anchor source=d_productbrandslist.srd kind=datawindow-codebehind
using Microsoft.AspNetCore.Components;
using MudBlazor;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Blazor.Services;

namespace ProductCatalog.Blazor.Components.DataWindows;

public partial class Productbrandslist : ComponentBase
{
    [Inject] private ProductbrandslistService _svc { get; set; } = default!;
    [Inject] private ISnackbar Snackbar { get; set; } = default!;

    internal IReadOnlyList<ProductbrandslistDto> _rows = Array.Empty<ProductbrandslistDto>();
    internal ProductbrandslistDto? _row;
    internal bool _loading;


    protected override async Task OnInitializedAsync() => await LoadAsync();

    internal void OnRowClick(DataGridRowClickEventArgs<ProductbrandslistDto> args)
    {
        _row = args.Item;
    }

    public async Task LoadAsync(CancellationToken ct = default)
    {
        _loading = true;
        try
        {
            _rows = await _svc.GetAllAsync(ct);
            _row = _rows.Count > 0 ? _rows[0] : null;
            
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Error loading data: {ex.Message}", Severity.Error);
        }
        finally
        {
            _loading = false;
        }
    }
}
