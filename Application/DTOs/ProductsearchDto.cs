// @pb-anchor source=d_productsearch.srd kind=dto style=Grid
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Application.DTOs;

/// <summary>
/// Auto-generated DTO for DataWindow: d_productsearch
/// Style: Grid
///
/// DESIGN RULES (enforced by pb-convert-dw-toolkit):
///   - MUST be a standalone record / class — NEVER inherit from a Domain entity.
///   - Flattens DW result-set columns. Entity/DTO boundary is mandatory so the
///     Application layer can evolve independently of EF Core entities.
/// </summary>
public class ProductsearchDto
{
    public int? ProductitemsId { get; set; }

    public string? ProductitemsName { get; set; }

    public double? ProductitemsPrice { get; set; }

    public string? ProductitemsImagename { get; set; }

    public string? ProductfeaturesTitle { get; set; }

    public string? ProductbrandsBrand { get; set; }

    public string? ProducttypesType { get; set; }

    public string? ProducttypesCode { get; set; }

    public string? TagsTag { get; set; }
}
