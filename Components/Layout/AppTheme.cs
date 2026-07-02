using MudBlazor;

namespace ProductCatalog.Blazor.Components.Layout;

/// <summary>Central MudTheme — matches the pb_project_config.json uiMode setting.</summary>
public static class AppTheme
{
    public const string UiMode = "modernized";

    public static readonly MudTheme Theme = new()
    {
        PaletteLight = new PaletteLight { Primary = "#1976d2", Secondary = "#9c27b0", Background = "#fafafa", Surface = "#ffffff", DrawerBackground = "#fafafa", AppbarBackground = "#1976d2" },
        Typography = new Typography
        {
            Default = new DefaultTypography { FontFamily = new[] { "Roboto", "Helvetica", "sans-serif" }, FontSize = "14px" }
        },
        LayoutProperties = new LayoutProperties
        {
            DefaultBorderRadius = "4px"
        }
    };
}
