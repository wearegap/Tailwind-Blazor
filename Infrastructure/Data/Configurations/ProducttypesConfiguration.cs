// @pb-anchor source=d_producttypes.srd kind=ef-configuration
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Infrastructure.Data.Configurations;

/// <summary>
/// EF configuration for <see cref="ProducttypesDto"/>.
/// Table mapping derived from the DW's primary SELECT; column types will be
/// refined when a live DB schema is available. Without a connection string,
/// EF falls back to convention-based mapping for any property not pinned here.
/// </summary>
public class ProducttypesConfiguration : IEntityTypeConfiguration<ProducttypesDto>
{
    public void Configure(EntityTypeBuilder<ProducttypesDto> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
