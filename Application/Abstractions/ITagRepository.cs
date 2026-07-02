// @pb-anchor source=d_tag.srd kind=repository-interface
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Application.Abstractions;

/// <summary>
/// Contract for <see cref="TagDto"/> access backed by DataWindow
/// <c>d_tag</c>. Implementations live in Infrastructure.
/// </summary>
public interface ITagRepository
{
    Task<IReadOnlyList<TagDto>> GetAllAsync(CancellationToken ct = default);
    Task<TagDto?>                GetByIdAsync(int id, CancellationToken ct = default);
    Task<TagDto>                 CreateAsync(TagDto row, CancellationToken ct = default);
    Task                             UpdateAsync(TagDto row, CancellationToken ct = default);
    Task                             DeleteAsync(int id, CancellationToken ct = default);
}
