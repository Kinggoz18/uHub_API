using uHubAPI.Models.MarketplaceModels;
using Microsoft.EntityFrameworkCore;

namespace uHubAPI.Lib.Configurations
{
    public static class MarketplaceConfiguration
    {
        public static ModelBuilder MarketplacePrice(this ModelBuilder modelBuilder)
        {
            //MarketplaceItem Price configuration
            modelBuilder.Entity<MarketplaceItem>()
                    .Property(m => m.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasPrecision(18, 2);

            return modelBuilder;
        }

        public static ModelBuilder MarketplaceItemToSellersAdd(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MarketplaceItem>()
                .HasOne(e => e.SellerAddress)
                .WithMany(e => e.MarketplaceItem)
                .HasForeignKey(e => e.SellerAddressId)
                .IsRequired();

            return modelBuilder;
        }

        public static ModelBuilder MarketplaceItemToWishlist(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MarketplaceItem>()
                .HasOne(e => e.Wishlist)
                .WithMany(e => e.MarketplaceItem)
                .HasForeignKey(e => e.WishlistId)
                .IsRequired();

            return modelBuilder;
        }
        public static ModelBuilder MarketplaceItemToCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.MarketplaceItem)
                .WithOne(e => e.Category)
                .HasForeignKey(e => e.CategoryId)
                .IsRequired();

            return modelBuilder;
        }
    }
}