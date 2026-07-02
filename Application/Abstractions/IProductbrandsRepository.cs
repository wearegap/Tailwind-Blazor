// @pb-anchor source=d_productbrands.srd kind=repository-interface
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Application.Abstractions;

/// <summary>
/// Contract for <see cref="ProductbrandsDto"/> access backed by DataWindow
/// <c>d_productbrands</c>. Implementations live in Infrastructure.
/// </summary>
public interface IProductbrandsRepository
{
    Task<IReadOnlyList<ProductbrandsDto>> GetAllAsync(CancellationToken ct = default);
    Task<ProductbrandsDto?>                GetByIdAsync(int id, CancellationToken ct = default);
    Task<ProductbrandsDto>                 CreateAsync(ProductbrandsDto row, CancellationToken ct = default);
    Task                             UpdateAsync(ProductbrandsDto row, CancellationToken ct = default);
    Task                             DeleteAsync(int id, CancellationToken ct = default);
}
