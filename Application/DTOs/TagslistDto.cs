// @pb-anchor source=d_tagslist.srd kind=dto style=Grid
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Application.DTOs;

/// <summary>
/// Auto-generated DTO for DataWindow: d_tagslist
/// Style: Grid
///
/// DESIGN RULES (enforced by pb-convert-dw-toolkit):
///   - MUST be a standalone record / class — NEVER inherit from a Domain entity.
///   - Flattens DW result-set columns. Entity/DTO boundary is mandatory so the
///     Application layer can evolve independently of EF Core entities.
/// </summary>
public class TagslistDto
{
    [Key]
    public int Id { get; set; }

    public string? Value { get; set; }
}
