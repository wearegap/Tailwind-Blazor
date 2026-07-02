// @pb-anchor source=d_productfeatures.srd kind=datawindow-service
using ProductCatalog.Application.Abstractions;
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Blazor.Services;

public class ProductfeaturesService
{
    private readonly IProductfeaturesRepository _repo;
    public ProductfeaturesService(IProductfeaturesRepository repo) => _repo = repo;

    public Task<IReadOnlyList<ProductfeaturesDto>> GetAllAsync(CancellationToken ct = default)
        => _repo.GetAllAsync(ct);

    public Task SaveAsync(ProductfeaturesDto row, CancellationToken ct = default)
        => _repo.UpdateAsync(row, ct);

    public Task DeleteAsync(int id, CancellationToken ct = default)
        => _repo.DeleteAsync(id, ct);
}
