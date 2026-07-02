// @pb-anchor source=d_tagslist.srd kind=datawindow-service
using ProductCatalog.Application.Abstractions;
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Blazor.Services;

public class TagslistService
{
    private readonly ITagslistRepository _repo;
    public TagslistService(ITagslistRepository repo) => _repo = repo;

    public Task<IReadOnlyList<TagslistDto>> GetAllAsync(CancellationToken ct = default)
        => _repo.GetAllAsync(ct);

    public Task SaveAsync(TagslistDto row, CancellationToken ct = default)
        => _repo.UpdateAsync(row, ct);

    public Task DeleteAsync(int id, CancellationToken ct = default)
        => _repo.DeleteAsync(id, ct);
}
