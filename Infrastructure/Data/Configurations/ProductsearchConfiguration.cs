// @pb-anchor source=d_productsearch.srd kind=ef-configuration
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Infrastructure.Data.Configurations;

public class ProductsearchConfiguration : IEntityTypeConfiguration<ProductsearchDto>
{
    public void Configure(EntityTypeBuilder<ProductsearchDto> builder)
    {
        builder.HasNoKey();
    }
}
