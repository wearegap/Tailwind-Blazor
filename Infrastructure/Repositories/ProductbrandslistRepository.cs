// @pb-anchor source=d_productbrandslist.srd kind=repository
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.Abstractions;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Infrastructure.Data;

namespace ProductCatalog.Infrastructure.DataWindows;

public class ProductbrandslistRepository : IProductbrandslistRepository
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    public ProductbrandslistRepository(IDbContextFactory<AppDbContext> factory) => _factory = factory;

    public async Task<IReadOnlyList<ProductbrandslistDto>> GetAllAsync(CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        return await db.Productbrands.AsNoTracking()
            .Select(x => new ProductbrandslistDto
            {
                Id = x.Id,
                Name = x.Name,
            })
            .ToListAsync(ct);
    }

    public async Task<ProductbrandslistDto?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        return await db.Productbrands.AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new ProductbrandslistDto
            {
                Id = x.Id,
                Name = x.Name,
            })
            .FirstOrDefaultAsync(ct);
    }

    public async Task<ProductbrandslistDto> CreateAsync(ProductbrandslistDto row, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        var entity = new ProductbrandsDto();
        entity.Id = row.Id;
        entity.Name = row.Name;
        db.Productbrands.Add(entity);
        await db.SaveChangesAsync(ct);
        row.Id = entity.Id;
        return row;
    }

    public async Task UpdateAsync(ProductbrandslistDto row, CancellationToken ct = default)
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
