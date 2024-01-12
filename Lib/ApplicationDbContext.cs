using Microsoft.EntityFrameworkCore;
using uHub_API.Models;

namespace uHub_API.Lib
{
    /// <summary>
    /// Database context for all schemas in the Model
    /// </summary>
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){
    }
    //DbSet properties for the entities

    //Account Management
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<UserRole> UserRoles {get; set; }
    public DbSet<OrderHistory> OrderHistories { get; set; }
    public DbSet<SellerAddress> SellerAddresses { get; set; }
    public DbSet<UserPoint> UserPoints {get; set; }
    public DbSet<PointDetail> PointDetails { get; set; }

    //Marketplaces
    public DbSet<MarketplaceItem> MarketplaceItems { get; set; }
    public DbSet<MarketplaceItemImage> MarketplaceItemImages { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //MarketplaceItem configurations
        modelBuilder.Entity<MarketplaceItem>()
                .Property(m => m.Price)
                .HasColumnType("decimal(18, 2)");

        //other configurations

        base.OnModelCreating(modelBuilder);
     }

    }

}