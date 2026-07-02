// @pb-anchor source=d_producttypes.srd kind=datawindow-service
using ProductCatalog.Application.Abstractions;
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Blazor.Services;

public class ProducttypesService
{
    private readonly IProducttypesRepository _repo;
    public ProducttypesService(IProducttypesRepository repo) => _repo = repo;

    public Task<IReadOnlyList<ProducttypesDto>> GetAllAsync(CancellationToken ct = default)
        => _repo.GetAllAsync(ct);

    public Task SaveAsync(ProducttypesDto row, CancellationToken ct = default)
        => _repo.UpdateAsync(row, ct);

    public Task DeleteAsync(int id, CancellationToken ct = default)
        => _repo.DeleteAsync(id, ct);
}
