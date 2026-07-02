// @pb-anchor source=d_producttypes.srd kind=datawindow-page-codebehind
using Microsoft.AspNetCore.Components;

namespace ProductCatalog.Blazor.Components.Pages.Producttypes;

/// <summary>
/// Auto-generated routable page wrapper for the d_producttypes DataWindow. The actual
/// data binding + grid/form rendering lives in the Producttypes component under
/// Components/DataWindows/. This page just hosts that component at /producttypes.
/// Add per-page logic (filters, breadcrumbs, query-string handling) here.
///
/// Class is named `ProducttypesPage` (not `Producttypes`) so Razor's tag-helper
/// resolver can disambiguate this routable page from the embedded DW component
/// — they live in different namespaces but share the same simple type name,
/// which Razor rejects with RZ9985 unless one of them is renamed.
/// </summary>
public partial class ProducttypesPage : ComponentBase
{
    [Parameter, SupplyParameterFromQuery] public string? Filter { get; set; }

    protected override void OnInitialized()
    {
        // Intentionally empty — child component handles its own load. Override
        // when the page needs to react to route or query-string parameters.
    }
}
