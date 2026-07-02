// @pb-anchor source=d_productitems.srd kind=repository-interface
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Application.Abstractions;

/// <summary>
/// Contract for <see cref="ProductitemsDto"/> access backed by DataWindow
/// <c>d_productitems</c>. Implementations live in Infrastructure.
/// </summary>
public interface IProductitemsRepository
{
    Task<IReadOnlyList<ProductitemsDto>> GetAllAsync(CancellationToken ct = default);
    Task<ProductitemsDto?>                GetByIdAsync(int id, CancellationToken ct = default);
    Task<ProductitemsDto>                 CreateAsync(ProductitemsDto row, CancellationToken ct = default);
    Task                             UpdateAsync(ProductitemsDto row, CancellationToken ct = default);
    Task                             DeleteAsync(int id, CancellationToken ct = default);
}
