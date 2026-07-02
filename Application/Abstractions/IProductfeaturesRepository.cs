// @pb-anchor source=d_productfeatures.srd kind=repository-interface
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Application.Abstractions;

/// <summary>
/// Contract for <see cref="ProductfeaturesDto"/> access backed by DataWindow
/// <c>d_productfeatures</c>. Implementations live in Infrastructure.
/// </summary>
public interface IProductfeaturesRepository
{
    Task<IReadOnlyList<ProductfeaturesDto>> GetAllAsync(CancellationToken ct = default);
    Task<ProductfeaturesDto?>                GetByIdAsync(int id, CancellationToken ct = default);
    Task<ProductfeaturesDto>                 CreateAsync(ProductfeaturesDto row, CancellationToken ct = default);
    Task                             UpdateAsync(ProductfeaturesDto row, CancellationToken ct = default);
    Task                             DeleteAsync(int id, CancellationToken ct = default);
}
