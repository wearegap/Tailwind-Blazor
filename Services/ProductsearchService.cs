// @pb-anchor source=d_productsearch.srd kind=datawindow-service
using ProductCatalog.Application.Abstractions;
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Blazor.Services;

public class ProductsearchService
{
    private readonly IProductsearchRepository _repo;
    public ProductsearchService(IProductsearchRepository repo) => _repo = repo;

    public Task<IReadOnlyList<ProductsearchDto>> GetAllAsync(CancellationToken ct = default)
        => _repo.GetAllAsync(ct);

    public Task<IReadOnlyList<ProductsearchDto>> SearchAsync(string keyword, CancellationToken ct = default)
        => _repo.SearchAsync(keyword, ct);
}
