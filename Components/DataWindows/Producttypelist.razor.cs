// @pb-anchor source=d_producttypelist.srd kind=datawindow-codebehind
using Microsoft.AspNetCore.Components;
using MudBlazor;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Blazor.Services;

namespace ProductCatalog.Blazor.Components.DataWindows;

public partial class Producttypelist : ComponentBase
{
    [Inject] private ProducttypelistService _svc { get; set; } = default!;
    [Inject] private ISnackbar Snackbar { get; set; } = default!;

    internal IReadOnlyList<ProducttypelistDto> _rows = Array.Empty<ProducttypelistDto>();
    internal ProducttypelistDto? _row;
    internal bool _loading;


    protected override async Task OnInitializedAsync() => await LoadAsync();

    internal void OnRowClick(DataGridRowClickEventArgs<ProducttypelistDto> args)
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
