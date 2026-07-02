// @pb-anchor source=d_productbrandslist.srd kind=repository-interface
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Application.Abstractions;

/// <summary>
/// Contract for <see cref="ProductbrandslistDto"/> access backed by DataWindow
/// <c>d_productbrandslist</c>. Implementations live in Infrastructure.
/// </summary>
public interface IProductbrandslistRepository
{
    Task<IReadOnlyList<ProductbrandslistDto>> GetAllAsync(CancellationToken ct = default);
    Task<ProductbrandslistDto?>                GetByIdAsync(int id, CancellationToken ct = default);
    Task<ProductbrandslistDto>                 CreateAsync(ProductbrandslistDto row, CancellationToken ct = default);
    Task                             UpdateAsync(ProductbrandslistDto row, CancellationToken ct = default);
    Task                             DeleteAsync(int id, CancellationToken ct = default);
}
