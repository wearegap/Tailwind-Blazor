// @pb-anchor source=d_productsearch.srd kind=repository
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.Abstractions;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Infrastructure.Data;

namespace ProductCatalog.Infrastructure.DataWindows;

// JOIN-projection DW; tables = productitems, producttypes, tags, productbrands, productfeatures
public class ProductsearchRepository : IProductsearchRepository
{
    private readonly IDbContextFactory<AppDbContext> _factory;
    public ProductsearchRepository(IDbContextFactory<AppDbContext> factory) => _factory = factory;

    public Task<IReadOnlyList<ProductsearchDto>> GetAllAsync(CancellationToken ct = default)
        => SearchAsync("%", ct);

    public async Task<IReadOnlyList<ProductsearchDto>> SearchAsync(string keyword, CancellationToken ct = default)
    {
        var term = keyword.Trim('%');
        await using var db = await _factory.CreateDbContextAsync(ct);
        return await db.Productitems.AsNoTracking()
            .GroupJoin(db.Producttypes.AsNoTracking(),
                x => x.Typeid, ptypes => ptypes.Id,
                (x, ptypess) => new { x, ptypess })
            .SelectMany(g => g.ptypess.DefaultIfEmpty(),
                (g, ptypes) => new { pitems = g.x, ptypes })
            .GroupJoin(db.Tag.AsNoTracking(),
                x => x.pitems.Tagid, ptags => ptags.Id,
                (x, ptagss) => new { x, ptagss })
            .SelectMany(g => g.ptagss.DefaultIfEmpty(),
                (g, ptags) => new { pitems = g.x.pitems, ptypes = g.x.ptypes, ptags })
            .GroupJoin(db.Productbrands.AsNoTracking(),
                x => x.pitems.Brandid, pbrands => pbrands.Id,
                (x, pbrandss) => new { x, pbrandss })
            .SelectMany(g => g.pbrandss.DefaultIfEmpty(),
                (g, pbrands) => new { pitems = g.x.pitems, ptypes = g.x.ptypes, ptags = g.x.ptags, pbrands })
            .GroupJoin(db.Productfeatures.AsNoTracking(),
                x => x.pitems.Id, pfeatures => pfeatures.Productitemid,
                (x, pfeaturess) => new { x, pfeaturess })
            .SelectMany(g => g.pfeaturess.DefaultIfEmpty(),
                (g, pfeatures) => new { pitems = g.x.pitems, ptypes = g.x.ptypes, ptags = g.x.ptags, pbrands = g.x.pbrands, pfeatures })
            .Where(x =>
                term.Length == 0
                || (x.pitems.Name ?? "").Contains(term)
                || (x.ptypes != null && (x.ptypes.Name ?? "").Contains(term))
                || (x.ptypes != null && (x.ptypes.Code ?? "").Contains(term))
                || (x.pbrands != null && (x.pbrands.Name ?? "").Contains(term))
                || (x.pfeatures != null && (x.pfeatures.Title ?? "").Contains(term)))
            .Select(x => new ProductsearchDto
            {
                ProductitemsId = x.pitems.Id,
                ProductitemsName = x.pitems.Name,
                ProductitemsPrice = x.pitems.Price,
                ProductitemsImagename = x.pitems.Imagename,
                ProductfeaturesTitle = x.pfeatures != null ? x.pfeatures.Title : default,
                ProductbrandsBrand = x.pbrands != null ? x.pbrands.Name : default,
                ProducttypesType = x.ptypes != null ? x.ptypes.Name : default,
                ProducttypesCode = x.ptypes != null ? x.ptypes.Code : default,
                TagsTag = x.ptags != null ? x.ptags.Value : default,
            })
            .ToListAsync(ct);
    }

    public async Task<ProductsearchDto?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        var results = await SearchAsync("%", ct);
        return results.FirstOrDefault(x => x.ProductitemsId == id);
    }

    public Task<ProductsearchDto> CreateAsync(ProductsearchDto row, CancellationToken ct = default)
        => throw new NotSupportedException("Productsearch is a read-only JOIN projection.");
    public Task UpdateAsync(ProductsearchDto row, CancellationToken ct = default)
        => throw new NotSupportedException("Productsearch is a read-only JOIN projection.");
    public Task DeleteAsync(int id, CancellationToken ct = default)
        => throw new NotSupportedException("Productsearch is a read-only JOIN projection.");
}
