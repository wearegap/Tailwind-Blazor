// @pb-anchor source=d_productfeatures.srd kind=datawindow-codebehind
using Microsoft.AspNetCore.Components;
using MudBlazor;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Blazor.Services;

namespace ProductCatalog.Blazor.Components.DataWindows;

public partial class Productfeatures : ComponentBase
{
    [Inject] private ProductfeaturesService _svc { get; set; } = default!;
    [Inject] private ISnackbar Snackbar { get; set; } = default!;

    internal IReadOnlyList<ProductfeaturesDto> _rows = Array.Empty<ProductfeaturesDto>();
    internal ProductfeaturesDto? _row;
    internal bool _loading;

    internal int _currentIndex;


    protected override async Task OnInitializedAsync() => await LoadAsync();

    public async Task LoadAsync(CancellationToken ct = default)
    {
        _loading = true;
        try
        {
            _rows = await _svc.GetAllAsync(ct);
            _row = _rows.Count > 0 ? _rows[0] : null;
            _currentIndex = 0;
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

    // PB: cb_prev clicked — ScrollPriorPage()
    public void OnPrev()
    {
        if (_currentIndex > 0) { _currentIndex--; _row = _rows[_currentIndex]; StateHasChanged(); }
    }

    // PB: cb_next clicked — ScrollNextRow()
    public void OnNext()
    {
        if (_currentIndex < _rows.Count - 1) { _currentIndex++; _row = _rows[_currentIndex]; StateHasChanged(); }
    }

    // PB: cb_update clicked — Update()
    public async Task OnSave()
    {
        if (_row is null) return;
        try
        {
            await _svc.SaveAsync(_row);
            Snackbar.Add("Saved.", MudBlazor.Severity.Success);
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Save failed: {ex.Message}", MudBlazor.Severity.Error);
        }
    }
}
