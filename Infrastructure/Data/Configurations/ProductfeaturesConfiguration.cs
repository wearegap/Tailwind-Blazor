// @pb-anchor source=d_productfeatures.srd kind=ef-configuration
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Infrastructure.Data.Configurations;

/// <summary>
/// EF configuration for <see cref="ProductfeaturesDto"/>.
/// Table mapping derived from the DW's primary SELECT; column types will be
/// refined when a live DB schema is available. Without a connection string,
/// EF falls back to convention-based mapping for any property not pinned here.
/// </summary>
public class ProductfeaturesConfiguration : IEntityTypeConfiguration<ProductfeaturesDto>
{
    public void Configure(EntityTypeBuilder<ProductfeaturesDto> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
