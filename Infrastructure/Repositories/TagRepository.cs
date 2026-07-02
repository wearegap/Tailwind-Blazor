// @pb-anchor source=d_tag.srd kind=repository
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.Abstractions;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Infrastructure.Data;

namespace ProductCatalog.Infrastructure.DataWindows;

/// <summary>
/// Repository for DataWindow: d_tag (Freeform).
/// Primary table: tags.
/// Auto-generated — follows DW_CONVERSION_PROMPT.md Step 2 rules.
/// ORDER BY = SQL ORDER() from SRD (not client-side sort=).
///
/// DESIGN: implements ITagRepository; uses IDbContextFactory so each
/// async operation gets its own short-lived DbContext — safe for Blazor Server.
/// </summary>
public class TagRepository : ITagRepository
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    public TagRepository(IDbContextFactory<AppDbContext> factory) => _factory = factory;

    public async Task<IReadOnlyList<TagDto>> GetAllAsync(CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        var q = db.Tag.AsNoTracking()
            .Select(x => new TagDto
            {
                Id = x.Id,
                Value = x.Value,
            });

        var ordered = q;

        return await ordered.ToListAsync(ct);
    }


    public async Task<TagDto?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        return await db.Tag.AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new TagDto {
                Id = x.Id,
                Value = x.Value,
            })
            .FirstOrDefaultAsync(ct);
    }

    public async Task<TagDto> CreateAsync(TagDto row, CancellationToken ct = default)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);
        var entity = new TagDto();
        entity.Id = row.Id;
        entity.Value = row.Value;
        db.Tag.Add(entity);
        await db.SaveChangesAsync(ct);
        return entity;
    }

    public async Task UpdateAsync(TagDto row, CancellationToken ct = default)
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
