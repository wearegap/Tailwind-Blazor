using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Serilog;
using ProductCatalog.Blazor.Components;
using ProductCatalog.Blazor.Components.Layout;
using ProductCatalog.Blazor.Services;
using ProductCatalog.Infrastructure;
using ProductCatalog.Infrastructure.Data;

// Structured logging (Serilog) — bootstrap logger captures startup exceptions.
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/app-.log", rollingInterval: RollingInterval.Day)
    .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);

// Replace the default host logger with Serilog (reads appsettings.json "Serilog" section).
builder.Host.UseSerilog((ctx, services, cfg) => cfg
    .ReadFrom.Configuration(ctx.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("Logs/app-.log", rollingInterval: RollingInterval.Day));

// Explicit AddLogging makes ILogger<T> registration unambiguous for DI discovery.
builder.Services.AddLogging();

// Razor Components + interactive server rendering (non-negotiable for MudBlazor).
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddMudServices();

// Liveness + readiness endpoints for container orchestrators.
builder.Services.AddHealthChecks();

builder.Services.AddAuthorization();

// Data layer.
builder.Services.AddInfrastructure();

// Scoped UI state services (expand via pb-convert-window-agent per page).
builder.Services.AddScoped<AuthState>();
builder.Services.AddScoped<AppActionState>();

// Blazor frontend data services — one AddScoped per DataWindow (pb-convert-dw-agent appends here).

builder.Services.AddScoped<ProductbrandslistService>();
builder.Services.AddScoped<ProductbrandsService>();
builder.Services.AddScoped<ProductfeaturesService>();
builder.Services.AddScoped<ProductitemsService>();
// Singleton image catalog — indexes wwwroot/images/ once at startup via IFileProvider.
builder.Services.AddSingleton<ImageCatalog>();
builder.Services.AddScoped<ProductsearchService>();
builder.Services.AddScoped<ProducttypelistService>();
builder.Services.AddScoped<ProducttypesService>();
builder.Services.AddScoped<TagService>();
builder.Services.AddScoped<TagslistService>();
var app = builder.Build();

// Seed in-memory database at startup.
await using (var scope = app.Services.CreateAsyncScope())
{
    var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();
    await InMemoryDataSeeder.SeedAsync(factory);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseStaticFiles();           // MUST appear BEFORE MapStaticAssets so _content/MudBlazor/* is served.
app.MapStaticAssets();
app.UseAntiforgery();

app.UseAuthorization();

// Liveness: fast 200 OK if the SignalR circuit layer is alive.
app.MapHealthChecks("/health");
app.MapHealthChecks("/health/ready");

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
