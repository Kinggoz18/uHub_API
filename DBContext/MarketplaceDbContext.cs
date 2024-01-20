using Microsoft.EntityFrameworkCore;
using uHubAPI.Models.MarketplaceModels;
using uHubAPI.Lib.Configurations;

namespace uHubAPI.DBContext
{
    /// <summary>
    /// Database context of all markeplace relaeted entities in the database
    /// </summary>
    public class MarketplaceDbContext : DbContext
    {
        public MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options) : base(options)
        {

        }

        // Properties for marketplace entities
        public DbSet<MarketplaceItem> MarketplaceItems { get; set; }
        public DbSet<MarketplaceItemImage> MarketplaceItemImages { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Marketplace configurations
            modelBuilder
                .MarketplacePrice()
                //Relationship configurations
                .MarketplaceImageToItem()
                .MarketplaceItemToCategory()
                .MarketplaceItemToOrderHistory()
                .MarketplaceItemToSellersAdd()
                .MarketplaceItemToWishlist();

            base.OnModelCreating(modelBuilder);
        }

    }

}