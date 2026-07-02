// @pb-anchor source=d_productitems.srd kind=ef-configuration
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Infrastructure.Data.Configurations;

/// <summary>
/// EF configuration for <see cref="ProductitemsDto"/>.
/// Table mapping derived from the DW's primary SELECT; column types will be
/// refined when a live DB schema is available. Without a connection string,
/// EF falls back to convention-based mapping for any property not pinned here.
/// </summary>
public class ProductitemsConfiguration : IEntityTypeConfiguration<ProductitemsDto>
{
    public void Configure(EntityTypeBuilder<ProductitemsDto> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
