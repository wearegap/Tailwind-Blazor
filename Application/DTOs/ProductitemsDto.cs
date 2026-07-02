// @pb-anchor source=d_productitems.srd kind=dto style=Freeform
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Application.DTOs;

/// <summary>
/// Auto-generated DTO for DataWindow: d_productitems
/// Style: Freeform
///
/// DESIGN RULES (enforced by pb-convert-dw-toolkit):
///   - MUST be a standalone record / class — NEVER inherit from a Domain entity.
///   - Flattens DW result-set columns. Entity/DTO boundary is mandatory so the
///     Application layer can evolve independently of EF Core entities.
/// </summary>
public class ProductitemsDto
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public double? Price { get; set; }

    public string? Imagename { get; set; }

    public int? Brandid { get; set; }

    public int? Typeid { get; set; }

    public int? Tagid { get; set; }
}
