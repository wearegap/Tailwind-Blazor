// @pb-anchor source=d_productitems.srd kind=repository
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.Abstractions;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Infrastructure.Data;

namespace ProductCatalog.Infrastructure.DataWindows;

/// <summary>
/// Repository for DataWindow: d_productitems (Freeform).
/// Primary table: productitems.
/// Auto-generated — follows DW_CONVERSION_PROMPT.md Step 2 rules.
/// ORDER BY = SQL ORDER() from SRD (not client-side sort=).
///
/// DESIGN: implements IProductitemsRepository; uses IDbContextFactory so each
/// async operation gets its own short-lived DbContext — safe for Blazor Server.
/// </summary>
public class ProductitemsRepository : IProductitemsRepository
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    public ProductitemsRepository(IDbContextFactory<AppDbContext> factory) => _factory = factory;

    public async Task<IReadOnlyList<ProductitemsDto>> GetAllAsync(CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        var q = db.Productitems.AsNoTracking()
            .Select(x => new ProductitemsDto
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Imagename = x.Imagename,
                Brandid = x.Brandid,
                Typeid = x.Typeid,
                Tagid = x.Tagid,
            });

        var ordered = q;

        return await ordered.ToListAsync(ct);
    }


    public async Task<ProductitemsDto?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        return await db.Productitems.AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new ProductitemsDto {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Imagename = x.Imagename,
                Brandid = x.Brandid,
                Typeid = x.Typeid,
                Tagid = x.Tagid,
            })
            .FirstOrDefaultAsync(ct);
    }

    public async Task<ProductitemsDto> CreateAsync(ProductitemsDto row, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        var entity = new ProductitemsDto();
        entity.Id = row.Id;
        entity.Name = row.Name;
        entity.Price = row.Price;
        entity.Imagename = row.Imagename;
        entity.Brandid = row.Brandid;
        entity.Typeid = row.Typeid;
        entity.Tagid = row.Tagid;
        db.Productitems.Add(entity);
        await db.SaveChangesAsync(ct);
        return entity;
    }

    public async Task UpdateAsync(ProductitemsDto row, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        var entity = await db.Productitems.FindAsync(new object?[] { row.Id }, ct);
        if (entity is null) return;
        entity.Name = row.Name;
        entity.Price = row.Price;
        entity.Imagename = row.Imagename;
        entity.Brandid = row.Brandid;
        entity.Typeid = row.Typeid;
        entity.Tagid = row.Tagid;
        await db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        var entity = await db.Productitems.FindAsync(new object?[] { id }, ct);
        if (entity is null) return;
        db.Productitems.Remove(entity);
        await db.SaveChangesAsync(ct);
    }

}
