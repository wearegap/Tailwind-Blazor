# ProductCatalog.Blazor
**Product Catalog — Blazor Server Application**

## Overview

ProductCatalog.Blazor is a Blazor Server application built on .NET 10 that presents a product catalog (brands, types, items, features, and tags). It is derived from the Microsoft TailWind Traders dataset and uses an in-memory Entity Framework Core database seeded at startup, so no external database or connection string is required.

---

## Modernization with VELO

This application is the result of an automated modernization of a legacy PowerBuilder desktop application, carried out using **VELO** — an AI-powered application modernization platform.

### Original Application

The source PowerBuilder project is preserved in the zip file at the root of this repository:

```
TailwindPowerBuilderSrc.zip
```

Extract the archive to inspect the original PowerBuilder source code (`.pbl`, `.pbt`, and DataWindow objects) from which this Blazor application was generated.

### What VELO Did

VELO analyzed the PowerBuilder source (windows, DataWindows, business logic, and PowerScript) and automatically produced:

- A layered .NET 10 / Blazor Server solution
- EF Core entity models and repository classes derived from DataWindows
- MudBlazor UI components that mirror the original window layouts
- Application-layer DTOs and repository abstractions
- Serilog structured logging and ASP.NET Core health checks

### Side-by-Side Visual Comparison

A screen recording that places the original PowerBuilder application next to the modernized Blazor application for visual comparison is available at the root of this repository:

```
Tailwind_Blazor_vs_PowerBuilder.mp4
```

This recording demonstrates UI parity between the legacy desktop UI and the new web-based Blazor application.

---

## Solution Structure

```
ProductCatalog.Blazor/
│
├── Application/                        Application layer (framework-agnostic)
│   ├── Abstractions/                   Interfaces consumed by the UI and infrastructure
│   │   ├── IApplicationContext.cs      User / environment info (UserID, UserName, etc.)
│   │   ├── IProductitemsRepository.cs
│   │   ├── IProductbrandsRepository.cs
│   │   ├── IProducttypesRepository.cs
│   │   ├── IProductfeaturesRepository.cs
│   │   ├── ITagRepository.cs
│   │   └── (list/search variants)
│   └── DTOs/                           Plain data-transfer objects shared across layers
│
├── Infrastructure/                     Data-access and cross-cutting concerns
│   ├── Data/
│   │   ├── AppDbContext.cs             EF Core DbContext (partial — DbSets added per entity)
│   │   ├── DbSets/                     One partial class per aggregate root
│   │   ├── Configurations/             IEntityTypeConfiguration<T> per entity
│   │   └── InMemoryDataSeeder.cs       Seeds brands, types, items, features and tags at startup
│   ├── Context/
│   │   └── ApplicationContext.cs       IApplicationContext backed by HttpContext claims
│   ├── Repositories/                   EF Core repository implementations
│   └── DependencyInjection.cs          AddInfrastructure() extension method
│
├── Components/                         Blazor UI layer
│   ├── App.razor                       Root component and router
│   ├── Routes.razor
│   ├── Layout/
│   │   ├── MainLayout.razor            Shell layout (nav, theme)
│   │   ├── NavMenu.razor
│   │   ├── AppTheme.cs                 MudBlazor theme configuration
│   │   ├── AppActionState.cs           Scoped action-state (toolbar, buttons)
│   │   └── AuthState.cs                Scoped authentication state wrapper
│   ├── Pages/                          Route-bearing pages (one folder per feature)
│   │   ├── Productitems/
│   │   ├── Productbrands/
│   │   ├── Producttypes/
│   │   ├── Productfeatures/
│   │   ├── Productsearch/
│   │   ├── Tag/ and Tagslist/
│   │   └── WMain.razor (and W*.razor)  Window-shell wrappers
│   └── DataWindows/                    Reusable data-bound components (one per entity)
│
├── Services/                           Scoped Blazor-side services (call repositories, map DTOs)
│   ├── ProductitemsService.cs
│   ├── ProductbrandsService.cs
│   ├── ProductsearchService.cs
│   ├── ImageCatalog.cs                 Singleton; indexes wwwroot/images/ at startup
│   └── (one service per feature)
│
├── Program.cs                          Startup: DI, middleware pipeline, seeding
├── appsettings.json
└── ProductCatalog.Blazor.csproj
```

---

## Architecture

The project follows a Clean / Layered Architecture:

```
┌─────────────────────────────────────────────┐
│  Blazor Components  (Components/, Services/)│  Presentation
├─────────────────────────────────────────────┤
│  Application Abstractions  (DTOs, IRepos)   │  Application
├─────────────────────────────────────────────┤
│  Infrastructure  (EF Core, Repositories)    │  Data Access
└─────────────────────────────────────────────┘
```

### Key Patterns

| Pattern | Details |
|---|---|
| **Repository Pattern** | `IXRepository` / `XRepository` pairs, auto-registered by convention (`Assembly.GetTypes()` scan in `DI.cs`) |
| **DbContextFactory** | `IDbContextFactory<AppDbContext>` (Scoped) avoids Blazor circuit lifetime conflicts with `DbContext` |
| **Partial Classes** | `AppDbContext` DbSets are each in their own file (`Infrastructure/Data/DbSets/`) |
| **IEntityTypeConfiguration** | Entity mappings are decoupled from the context (`Infrastructure/Data/Configurations/`) |
| **Scoped UI State** | `AuthState` and `AppActionState` are scoped services shared across components within a circuit |

---

## Main Features

- **Product catalog browser** — list, filter, and view product items with images
- **Product search** — cross-entity search (`Productsearch` page/repository)
- **Product brands** — manage and browse brands (CRUD DataWindow)
- **Product types** — manage and browse product categories
- **Product features** — per-item feature details
- **Tags** — tagging system (`Tag` / `Tagslist` DataWindows)
- **Image catalog** — product images served from `wwwroot/images/` (product-list thumbnails + product-details images)
- **MudBlazor UI** — Material Design components (v9.3.0), dark/light theme
- **Structured logging** — Serilog writes to console and rolling daily log files under `Logs/`
- **Health endpoints** — `/health` and `/health/ready` for container orchestrators
- **In-memory database** — EF Core InMemory provider, no external DB required; data is seeded from TailWind Traders reference data

---

## Technology Stack

| Layer | Technology |
|---|---|
| Runtime | .NET 10 |
| UI Framework | Blazor Server (Interactive Server rendering) |
| Component Library | MudBlazor 9.3.0 |
| ORM | Entity Framework Core 10 (InMemory provider) |
| Logging | Serilog.AspNetCore 10 |
| Security | BCrypt.Net-Next 4.0.3 (password hashing) |
| Health Checks | Microsoft.AspNetCore.Diagnostics.HealthChecks (built-in) |

---

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- Visual Studio 2022+ with the **ASP.NET and web development** workload *(or VS Code with the C# Dev Kit extension)*

> No database engine, Docker, or external services are required.

---

## Build and Run

### Option 1 — Visual Studio

1. Open `ProductCatalog.Blazor.slnx`
2. Press **F5** (Debug) or **Ctrl+F5** (Run without debugging)
3. The browser opens automatically at `https://localhost:{port}`

### Option 2 — .NET CLI

1. Open a terminal and navigate to the solution root:

   ```sh
   cd ...\ProductCatalog.Blazor
   ```

2. Restore dependencies:

   ```sh
   dotnet restore
   ```

3. Build the solution:

   ```sh
   dotnet build
   ```

4. Run the application:

   ```sh
   dotnet run --project ProductCatalog.Blazor.csproj
   ```

5. Open the URL printed in the terminal (e.g. `https://localhost:7xxx`) or navigate to `https://localhost:5001`

### Option 3 — Publish (Self-Contained)

1. Publish a release build:

   ```sh
   dotnet publish ProductCatalog.Blazor.csproj -c Release -o ./publish
   ```

2. Run the published output:

   ```sh
   dotnet ./publish/ProductCatalog.Blazor.dll
   ```

### Notes

- The in-memory database is seeded automatically on every startup; no migration commands are needed.
- Log files are written to `Logs/app-<date>.log` relative to the working directory.
- Health checks are available at `/health` and `/health/ready` once running.

---

## Project Conventions

- One DataWindow component per entity (`Components/DataWindows/`)
- One Page folder per route (`Components/Pages/<Feature>/`)
- One Service class per feature (`Services/`)
- One Repository class per aggregate (`Infrastructure/Repositories/`)
- One EF configuration per entity (`Infrastructure/Data/Configurations/`)
- DbSets live in partial-class files (`Infrastructure/Data/DbSets/`)
