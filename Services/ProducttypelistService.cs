// @pb-anchor source=d_producttypelist.srd kind=datawindow-service
using ProductCatalog.Application.Abstractions;
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Blazor.Services;

public class ProducttypelistService
{
    private readonly IProducttypelistRepository _repo;
    public ProducttypelistService(IProducttypelistRepository repo) => _repo = repo;

    public Task<IReadOnlyList<ProducttypelistDto>> GetAllAsync(CancellationToken ct = default)
        => _repo.GetAllAsync(ct);

    public Task SaveAsync(ProducttypelistDto row, CancellationToken ct = default)
        => _repo.UpdateAsync(row, ct);

    public Task DeleteAsync(int id, CancellationToken ct = default)
        => _repo.DeleteAsync(id, ct);
}
