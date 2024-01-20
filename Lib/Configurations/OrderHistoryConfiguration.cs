using Microsoft.EntityFrameworkCore;
using uHubAPI.Models.UserAccountModels;
namespace uHubAPI.Lib.Configurations
{
	public static class OrderHistoryConfiguration
	{
		public static ModelBuilder AppUserToOrderHistory(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<OrderHistory>()
				.HasOne(e => e.AppUser)
				.WithMany(e => e.OrderHistory)
				.HasForeignKey(e => e.AppUserId)
				.IsRequired();
			return modelBuilder;
		}

        public static ModelBuilder MarketplaceItemToOrderHistory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderHistory>()
                .HasOne(e => e.MarketplaceItem)
                .WithOne(e => e.OrderHistory)
                .HasForeignKey<OrderHistory>(e => e.Uuid)
                .IsRequired();
            return modelBuilder;
        }
    }
}

