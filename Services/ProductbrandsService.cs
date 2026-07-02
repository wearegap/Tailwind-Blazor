// @pb-anchor source=d_productbrands.srd kind=datawindow-service
using ProductCatalog.Application.Abstractions;
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Blazor.Services;

public class ProductbrandsService
{
    private readonly IProductbrandsRepository _repo;
    public ProductbrandsService(IProductbrandsRepository repo) => _repo = repo;

    public Task<IReadOnlyList<ProductbrandsDto>> GetAllAsync(CancellationToken ct = default)
        => _repo.GetAllAsync(ct);

    public Task SaveAsync(ProductbrandsDto row, CancellationToken ct = default)
        => _repo.UpdateAsync(row, ct);

    public Task DeleteAsync(int id, CancellationToken ct = default)
        => _repo.DeleteAsync(id, ct);
}
