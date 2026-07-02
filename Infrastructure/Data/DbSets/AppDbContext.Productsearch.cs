// @pb-anchor source=d_productsearch.srd kind=dbset
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Infrastructure.Data;

public partial class AppDbContext
{
    public DbSet<ProductsearchDto> Productsearch => Set<ProductsearchDto>();
}
