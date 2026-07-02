using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace ProductCatalog.Blazor.Components.Layout;

/// <summary>Scoped ProtectedSessionStorage-backed auth — survives prerender → interactive transition.</summary>
public class AuthState(ProtectedSessionStorage storage)
{
    private const string Key = "auth";
    private string? _userId;
    private string? _userName;
    private bool _loaded;

    public string? UserId   => _userId;
    public string? UserName => _userName;
    public bool    IsAuthenticated => _userId is not null;

    public async Task LoadAsync()
    {
        if (_loaded) return;
        try
        {
            var r = await storage.GetAsync<string[]>(Key);
            if (r.Success && r.Value?.Length == 2) { _userId = r.Value[0]; _userName = r.Value[1]; }
        }
        catch { /* JS unavailable during prerender */ }
        _loaded = true;
    }

    public async Task SignInAsync(string userId, string userName)
    {
        _userId = userId; _userName = userName; _loaded = true;
        await storage.SetAsync(Key, new[] { userId, userName });
    }

    public async Task SignOutAsync()
    {
        _userId = null; _userName = null;
        await storage.DeleteAsync(Key);
    }
}
