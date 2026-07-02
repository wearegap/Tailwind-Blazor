// @pb-anchor source=d_tagslist.srd kind=repository-interface
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Application.Abstractions;

/// <summary>
/// Contract for <see cref="TagslistDto"/> access backed by DataWindow
/// <c>d_tagslist</c>. Implementations live in Infrastructure.
/// </summary>
public interface ITagslistRepository
{
    Task<IReadOnlyList<TagslistDto>> GetAllAsync(CancellationToken ct = default);
    Task<TagslistDto?>                GetByIdAsync(int id, CancellationToken ct = default);
    Task<TagslistDto>                 CreateAsync(TagslistDto row, CancellationToken ct = default);
    Task                             UpdateAsync(TagslistDto row, CancellationToken ct = default);
    Task                             DeleteAsync(int id, CancellationToken ct = default);
}
