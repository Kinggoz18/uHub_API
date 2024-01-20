using Microsoft.EntityFrameworkCore;
using uHubAPI.Models.UserAccountModels;

namespace uHubAPI.Lib.Configurations
{
	public static class WishlistConfiguration
	{
		public static ModelBuilder WishlistToAppUser(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Wishlist>()
				.HasOne(e => e.AppUser)
				.WithOne(e => e.Wishlist)
				.HasForeignKey<Wishlist>(e => e.AppUserId)
				.IsRequired();

			return modelBuilder;
		}
	}
}

