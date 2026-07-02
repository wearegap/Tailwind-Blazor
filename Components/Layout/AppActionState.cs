namespace ProductCatalog.Blazor.Components.Layout;

/// <summary>
/// Scoped action dispatcher — Phase 3.4/3.5 naming rule: disambiguate
/// menu collisions by menu-role prefix (BopSave, LogCancel), NOT numeric suffix.
/// </summary>
public class AppActionState
{
    public enum Action
    {
        // populated by pb-convert-menu-agent from the main menu (m_bop etc.)
        Find, Cancel, Insert, Modify, Delete, Save, Print,
    }

    public static readonly Dictionary<string, Action> AcceleratorMap = new()
    {
        // populated by pb-convert-menu-agent from SRM accelerators
        ["F2"]    = Action.Insert,
        ["F4"]    = Action.Modify,
        ["F12"]   = Action.Save,
        ["Ctrl+S"]= Action.Save,
        ["Ctrl+D"]= Action.Delete,
    };

    public event Func<Action, Task>? OnAction;

    public async Task Dispatch(Action action)
    {
        if (OnAction is not null) await OnAction.Invoke(action);
    }
}
