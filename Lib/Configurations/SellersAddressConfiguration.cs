using Microsoft.EntityFrameworkCore;
using uHubAPI.Models.UserAccountModels;
using uHubAPI.Models.MarketplaceModels;

namespace uHubAPI.Lib.Configurations
{
	public static class SellersAddressConfiguration
	{
		public static ModelBuilder SellersAddToAppUser(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SellerAddress>()
				.HasOne(e => e.AppUser)
				.WithOne(e => e.SellerAddress)
				.HasForeignKey<SellerAddress>(e => e.AppUserId)
				.IsRequired();

			return modelBuilder;
		}

	}

}

