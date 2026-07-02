// @pb-anchor source=d_productfeatures.srd kind=repository
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.Abstractions;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Infrastructure.Data;

namespace ProductCatalog.Infrastructure.DataWindows;

/// <summary>
/// Repository for DataWindow: d_productfeatures (Freeform).
/// Primary table: productfeatures.
/// Auto-generated — follows DW_CONVERSION_PROMPT.md Step 2 rules.
/// ORDER BY = SQL ORDER() from SRD (not client-side sort=).
///
/// DESIGN: implements IProductfeaturesRepository; uses IDbContextFactory so each
/// async operation gets its own short-lived DbContext — safe for Blazor Server.
/// </summary>
public class ProductfeaturesRepository : IProductfeaturesRepository
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    public ProductfeaturesRepository(IDbContextFactory<AppDbContext> factory) => _factory = factory;

    public async Task<IReadOnlyList<ProductfeaturesDto>> GetAllAsync(CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        var q = db.Productfeatures.AsNoTracking()
            .Select(x => new ProductfeaturesDto
            {
                Id = x.Id,
                Productitemid = x.Productitemid,
                Title = x.Title,
                Description = x.Description,
            });

        var ordered = q;

        return await ordered.ToListAsync(ct);
    }


    public async Task<ProductfeaturesDto?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        return await db.Productfeatures.AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new ProductfeaturesDto {
                Id = x.Id,
                Productitemid = x.Productitemid,
                Title = x.Title,
                Description = x.Description,
            })
            .FirstOrDefaultAsync(ct);
    }

    public async Task<ProductfeaturesDto> CreateAsync(ProductfeaturesDto row, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        var entity = new ProductfeaturesDto();
        entity.Id = row.Id;
        entity.Productitemid = row.Productitemid;
        entity.Title = row.Title;
        entity.Description = row.Description;
        db.Productfeatures.Add(entity);
        await db.SaveChangesAsync(ct);
        return entity;
    }

    public async Task UpdateAsync(ProductfeaturesDto row, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        var entity = await db.Productfeatures.FindAsync(new object?[] { row.Id }, ct);
        if (entity is null) return;
        entity.Productitemid = row.Productitemid;
        entity.Title = row.Title;
        entity.Description = row.Description;
        await db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        var entity = await db.Productfeatures.FindAsync(new object?[] { id }, ct);
        if (entity is null) return;
        db.Productfeatures.Remove(entity);
        await db.SaveChangesAsync(ct);
    }

}
