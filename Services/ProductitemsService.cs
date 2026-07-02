// @pb-anchor source=d_productitems.srd kind=datawindow-service
using ProductCatalog.Application.Abstractions;
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Blazor.Services;

public class ProductitemsService
{
    private readonly IProductitemsRepository _repo;
    public ProductitemsService(IProductitemsRepository repo) => _repo = repo;

    public Task<IReadOnlyList<ProductitemsDto>> GetAllAsync(CancellationToken ct = default)
        => _repo.GetAllAsync(ct);

    public Task SaveAsync(ProductitemsDto row, CancellationToken ct = default)
        => _repo.UpdateAsync(row, ct);

    public Task DeleteAsync(int id, CancellationToken ct = default)
        => _repo.DeleteAsync(id, ct);
}
