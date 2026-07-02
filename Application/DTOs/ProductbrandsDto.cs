// @pb-anchor source=d_productbrands.srd kind=dto style=Freeform
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Application.DTOs;

/// <summary>
/// Auto-generated DTO for DataWindow: d_productbrands
/// Style: Freeform
///
/// DESIGN RULES (enforced by pb-convert-dw-toolkit):
///   - MUST be a standalone record / class — NEVER inherit from a Domain entity.
///   - Flattens DW result-set columns. Entity/DTO boundary is mandatory so the
///     Application layer can evolve independently of EF Core entities.
/// </summary>
public class ProductbrandsDto
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }
}
