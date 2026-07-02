// @pb-anchor source=d_producttypes.srd kind=repository-interface
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Application.Abstractions;

/// <summary>
/// Contract for <see cref="ProducttypesDto"/> access backed by DataWindow
/// <c>d_producttypes</c>. Implementations live in Infrastructure.
/// </summary>
public interface IProducttypesRepository
{
    Task<IReadOnlyList<ProducttypesDto>> GetAllAsync(CancellationToken ct = default);
    Task<ProducttypesDto?>                GetByIdAsync(int id, CancellationToken ct = default);
    Task<ProducttypesDto>                 CreateAsync(ProducttypesDto row, CancellationToken ct = default);
    Task                             UpdateAsync(ProducttypesDto row, CancellationToken ct = default);
    Task                             DeleteAsync(int id, CancellationToken ct = default);
}
