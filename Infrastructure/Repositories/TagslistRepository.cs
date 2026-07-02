// @pb-anchor source=d_tagslist.srd kind=repository
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.Abstractions;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Infrastructure.Data;

namespace ProductCatalog.Infrastructure.DataWindows;

public class TagslistRepository : ITagslistRepository
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    public TagslistRepository(IDbContextFactory<AppDbContext> factory) => _factory = factory;

    public async Task<IReadOnlyList<TagslistDto>> GetAllAsync(CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        return await db.Tag.AsNoTracking()
            .Select(x => new TagslistDto
            {
                Id = x.Id,
                Value = x.Value,
            })
            .ToListAsync(ct);
    }

    public async Task<TagslistDto?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        return await db.Tag.AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new TagslistDto
            {
                Id = x.Id,
                Value = x.Value,
            })
            .FirstOrDefaultAsync(ct);
    }

    public async Task<TagslistDto> CreateAsync(TagslistDto row, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        var entity = new TagDto();
        entity.Id = row.Id;
        entity.Value = row.Value;
        db.Tag.Add(entity);
        await db.SaveChangesAsync(ct);
        row.Id = entity.Id;
        return row;
    }

    public async Task UpdateAsync(TagslistDto row, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        var entity = await db.Tag.FindAsync(new object?[] { row.Id }, ct);
        if (entity is null) return;
        entity.Value = row.Value;
        await db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        var entity = await db.Tag.FindAsync(new object?[] { id }, ct);
        if (entity is null) return;
        db.Tag.Remove(entity);
        await db.SaveChangesAsync(ct);
    }
}
