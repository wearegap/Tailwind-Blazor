// @pb-anchor source=d_productsearch.srd kind=repository-interface
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Application.Abstractions;

/// <summary>
/// Contract for <see cref="ProductsearchDto"/> access backed by DataWindow
/// <c>d_productsearch</c>. Implementations live in Infrastructure.
/// </summary>
public interface IProductsearchRepository
{
    Task<IReadOnlyList<ProductsearchDto>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<ProductsearchDto>> SearchAsync(string keyword, CancellationToken ct = default);
    Task<ProductsearchDto?>                GetByIdAsync(int id, CancellationToken ct = default);
    Task<ProductsearchDto>                 CreateAsync(ProductsearchDto row, CancellationToken ct = default);
    Task                             UpdateAsync(ProductsearchDto row, CancellationToken ct = default);
    Task                             DeleteAsync(int id, CancellationToken ct = default);
}
