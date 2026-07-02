// @pb-anchor source=d_producttypes.srd kind=repository
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.Abstractions;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Infrastructure.Data;

namespace ProductCatalog.Infrastructure.DataWindows;

/// <summary>
/// Repository for DataWindow: d_producttypes (Freeform).
/// Primary table: producttypes.
/// Auto-generated — follows DW_CONVERSION_PROMPT.md Step 2 rules.
/// ORDER BY = SQL ORDER() from SRD (not client-side sort=).
///
/// DESIGN: implements IProducttypesRepository; uses IDbContextFactory so each
/// async operation gets its own short-lived DbContext — safe for Blazor Server.
/// </summary>
public class ProducttypesRepository : IProducttypesRepository
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    public ProducttypesRepository(IDbContextFactory<AppDbContext> factory) => _factory = factory;

    public async Task<IReadOnlyList<ProducttypesDto>> GetAllAsync(CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        var q = db.Producttypes.AsNoTracking()
            .Select(x => new ProducttypesDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
            });

        var ordered = q;

        return await ordered.ToListAsync(ct);
    }


    public async Task<ProducttypesDto?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        return await db.Producttypes.AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new ProducttypesDto {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
            })
            .FirstOrDefaultAsync(ct);
    }

    public async Task<ProducttypesDto> CreateAsync(ProducttypesDto row, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        var entity = new ProducttypesDto();
        entity.Id = row.Id;
        entity.Name = row.Name;
        entity.Code = row.Code;
        db.Producttypes.Add(entity);
        await db.SaveChangesAsync(ct);
        return entity;
    }

    public async Task UpdateAsync(ProducttypesDto row, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        var entity = await db.Producttypes.FindAsync(new object?[] { row.Id }, ct);
        if (entity is null) return;
        entity.Name = row.Name;
        entity.Code = row.Code;
        await db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        var entity = await db.Producttypes.FindAsync(new object?[] { id }, ct);
        if (entity is null) return;
        db.Producttypes.Remove(entity);
        await db.SaveChangesAsync(ct);
    }

}
