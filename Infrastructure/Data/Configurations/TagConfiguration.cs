// @pb-anchor source=d_tag.srd kind=ef-configuration
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Infrastructure.Data.Configurations;

/// <summary>
/// EF configuration for <see cref="TagDto"/>.
/// Table mapping derived from the DW's primary SELECT; column types will be
/// refined when a live DB schema is available. Without a connection string,
/// EF falls back to convention-based mapping for any property not pinned here.
/// </summary>
public class TagConfiguration : IEntityTypeConfiguration<TagDto>
{
    public void Configure(EntityTypeBuilder<TagDto> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
