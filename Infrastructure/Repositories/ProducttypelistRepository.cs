// @pb-anchor source=d_producttypelist.srd kind=repository
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.Abstractions;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Infrastructure.Data;

namespace ProductCatalog.Infrastructure.DataWindows;

public class ProducttypelistRepository : IProducttypelistRepository
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    public ProducttypelistRepository(IDbContextFactory<AppDbContext> factory) => _factory = factory;

    public async Task<IReadOnlyList<ProducttypelistDto>> GetAllAsync(CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        return await db.Producttypes.AsNoTracking()
            .Select(x => new ProducttypelistDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
            })
            .ToListAsync(ct);
    }

    public async Task<ProducttypelistDto?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        return await db.Producttypes.AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new ProducttypelistDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
            })
            .FirstOrDefaultAsync(ct);
    }

    public async Task<ProducttypelistDto> CreateAsync(ProducttypelistDto row, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        var entity = new ProducttypesDto();
        entity.Id = row.Id;
        entity.Name = row.Name;
        entity.Code = row.Code;
        db.Producttypes.Add(entity);
        await db.SaveChangesAsync(ct);
        row.Id = entity.Id;
        return row;
    }

    public async Task UpdateAsync(ProducttypelistDto row, CancellationToken ct = default)
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
