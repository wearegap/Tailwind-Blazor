// @pb-anchor source=d_productbrands.srd kind=repository
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.Abstractions;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Infrastructure.Data;

namespace ProductCatalog.Infrastructure.DataWindows;

/// <summary>
/// Repository for DataWindow: d_productbrands (Freeform).
/// Primary table: productbrands.
/// Auto-generated — follows DW_CONVERSION_PROMPT.md Step 2 rules.
/// ORDER BY = SQL ORDER() from SRD (not client-side sort=).
///
/// DESIGN: implements IProductbrandsRepository; uses IDbContextFactory so each
/// async operation gets its own short-lived DbContext — safe for Blazor Server.
/// </summary>
public class ProductbrandsRepository : IProductbrandsRepository
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    public ProductbrandsRepository(IDbContextFactory<AppDbContext> factory) => _factory = factory;

    public async Task<IReadOnlyList<ProductbrandsDto>> GetAllAsync(CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        var q = db.Productbrands.AsNoTracking()
            .Select(x => new ProductbrandsDto
            {
                Id = x.Id,
                Name = x.Name,
            });

        var ordered = q;

        return await ordered.ToListAsync(ct);
    }


    public async Task<ProductbrandsDto?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        return await db.Productbrands.AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new ProductbrandsDto {
                Id = x.Id,
                Name = x.Name,
            })
            .FirstOrDefaultAsync(ct);
    }

    public async Task<ProductbrandsDto> CreateAsync(ProductbrandsDto row, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        var entity = new ProductbrandsDto();
        entity.Id = row.Id;
        entity.Name = row.Name;
        db.Productbrands.Add(entity);
        await db.SaveChangesAsync(ct);
        return entity;
    }

    public async Task UpdateAsync(ProductbrandsDto row, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        var entity = await db.Productbrands.FindAsync(new object?[] { row.Id }, ct);
        if (entity is null) return;
        entity.Name = row.Name;
        await db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        var entity = await db.Productbrands.FindAsync(new object?[] { id }, ct);
        if (entity is null) return;
        db.Productbrands.Remove(entity);
        await db.SaveChangesAsync(ct);
    }

}
