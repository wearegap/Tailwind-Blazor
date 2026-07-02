// @pb-anchor source=d_productbrands.srd kind=ef-configuration
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Infrastructure.Data.Configurations;

/// <summary>
/// EF configuration for <see cref="ProductbrandsDto"/>.
/// Table mapping derived from the DW's primary SELECT; column types will be
/// refined when a live DB schema is available. Without a connection string,
/// EF falls back to convention-based mapping for any property not pinned here.
/// </summary>
public class ProductbrandsConfiguration : IEntityTypeConfiguration<ProductbrandsDto>
{
    public void Configure(EntityTypeBuilder<ProductbrandsDto> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
