// @pb-anchor source=d_productbrandslist.srd kind=datawindow-service
using ProductCatalog.Application.Abstractions;
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Blazor.Services;

public class ProductbrandslistService
{
    private readonly IProductbrandslistRepository _repo;
    public ProductbrandslistService(IProductbrandslistRepository repo) => _repo = repo;

    public Task<IReadOnlyList<ProductbrandslistDto>> GetAllAsync(CancellationToken ct = default)
        => _repo.GetAllAsync(ct);

    public Task SaveAsync(ProductbrandslistDto row, CancellationToken ct = default)
        => _repo.UpdateAsync(row, ct);

    public Task DeleteAsync(int id, CancellationToken ct = default)
        => _repo.DeleteAsync(id, ct);
}
