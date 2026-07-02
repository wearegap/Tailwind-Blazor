// @pb-anchor source=d_producttypelist.srd kind=repository-interface
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Application.Abstractions;

/// <summary>
/// Contract for <see cref="ProducttypelistDto"/> access backed by DataWindow
/// <c>d_producttypelist</c>. Implementations live in Infrastructure.
/// </summary>
public interface IProducttypelistRepository
{
    Task<IReadOnlyList<ProducttypelistDto>> GetAllAsync(CancellationToken ct = default);
    Task<ProducttypelistDto?>                GetByIdAsync(int id, CancellationToken ct = default);
    Task<ProducttypelistDto>                 CreateAsync(ProducttypelistDto row, CancellationToken ct = default);
    Task                             UpdateAsync(ProducttypelistDto row, CancellationToken ct = default);
    Task                             DeleteAsync(int id, CancellationToken ct = default);
}
