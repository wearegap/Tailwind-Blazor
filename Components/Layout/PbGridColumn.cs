namespace ProductCatalog.Blazor.Components.Layout;

public sealed class PbGridColumn<TItem>
{
    public string Header   { get; init; } = "";
    public Func<TItem, object?> Value { get; init; } = _ => null;
    public string? CssClass { get; init; }
    public int?    Width    { get; init; }
}
