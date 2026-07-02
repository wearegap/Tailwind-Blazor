namespace ProductCatalog.Application.Abstractions;

/// <summary>
/// Ambient per-request context exposing the PB-era SystemInfo /
/// gs_* globals that translated PowerScript bodies depend on.
/// Scoped: resolved once per Blazor circuit / HTTP request.
/// </summary>
public interface IApplicationContext
{
    /// <summary>Currently-signed-in user id (SystemInfo.User.Id / gs_auth_user).</summary>
    string? UserId { get; }
    /// <summary>Display name for the signed-in user.</summary>
    string? UserName { get; }
    /// <summary>App code / environment identifier (SystemInfo.Application).</summary>
    string Application { get; }
    /// <summary>Three-letter base currency code (SystemInfo.BaseCurrency).</summary>
    string BaseCurrency { get; }
    /// <summary>Today (local date, no time) — SystemInfo.Today().</summary>
    DateTime Today { get; }
    /// <summary>Now (local datetime) — SystemInfo.Now().</summary>
    DateTime Now { get; }
    /// <summary>Active connection-profile alias (SystemInfo.Connections[...]).</summary>
    string? ConnectionAlias { get; }
    /// <summary>Arbitrary named setting lookup (SystemInfo.IniFile / appsettings).</summary>
    string? GetSetting(string key);
    /// <summary>Test whether the signed-in user has the given function-access flag.</summary>
    bool HasAccess(string functionCode);
}
