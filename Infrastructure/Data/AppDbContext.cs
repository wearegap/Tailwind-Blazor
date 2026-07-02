using Microsoft.EntityFrameworkCore;

namespace ProductCatalog.Infrastructure.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // DbSets will be added by pb-convert-dw (Skill 7)
    // Example: public DbSet<ProductItem> ProductItems => Set<ProductItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
