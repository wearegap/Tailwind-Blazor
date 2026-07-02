using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ProductCatalog.Application.Abstractions;

namespace ProductCatalog.Infrastructure.Context;

/// <summary>
/// Default <see cref="IApplicationContext"/> backed by HttpContext claims
/// and IConfiguration. Replace or extend per-project when PB code needs
/// additional SystemInfo.* fields.
/// </summary>
public sealed class ApplicationContext : IApplicationContext
{
    private readonly IHttpContextAccessor _http;
    private readonly IConfiguration _config;

    public ApplicationContext(IHttpContextAccessor http, IConfiguration config)
    {
        _http = http;
        _config = config;
    }

    public string? UserId =>
        _http.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
        ?? _http.HttpContext?.User?.Identity?.Name;

    public string? UserName =>
        _http.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value
        ?? _http.HttpContext?.User?.Identity?.Name;

    public string Application => _config["Application:Name"] ?? "ProductCatalog";
    public string BaseCurrency => _config["Application:BaseCurrency"] ?? "USD";
    public DateTime Today => DateTime.Today;
    public DateTime Now => DateTime.Now;
    public string? ConnectionAlias => _config["ConnectionStrings:Default"] is null ? null : "Default";

    public string? GetSetting(string key) => _config[key];

    public bool HasAccess(string functionCode)
    {
        // Claim convention: pb-access:{functionCode}. Populate during
        // sign-in based on admuseraccess / equivalent table.
        var claim = _http.HttpContext?.User?.FindFirst($"pb-access:{functionCode}");
        return claim?.Value == "1" || claim?.Value == "true";
    }
}
