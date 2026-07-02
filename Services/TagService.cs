// @pb-anchor source=d_tag.srd kind=datawindow-service
using ProductCatalog.Application.Abstractions;
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Blazor.Services;

public class TagService
{
    private readonly ITagRepository _repo;
    public TagService(ITagRepository repo) => _repo = repo;

    public Task<IReadOnlyList<TagDto>> GetAllAsync(CancellationToken ct = default)
        => _repo.GetAllAsync(ct);

    public Task SaveAsync(TagDto row, CancellationToken ct = default)
        => _repo.UpdateAsync(row, ct);

    public Task DeleteAsync(int id, CancellationToken ct = default)
        => _repo.DeleteAsync(id, ct);
}
