using Microsoft.EntityFrameworkCore;
using uHubAPI.Models.MarketplaceModels;

namespace uHubAPI.Lib.Configurations
{
	public static class MarketplaceItemImageConfiguration
	{
		public static ModelBuilder MarketplaceImageToItem(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MarketplaceItemImage>()
				.HasOne(e => e.MarketplaceItem)
				.WithMany(e => e.MarketplaceItemImage)
				.HasForeignKey(e => e.MarketplaceItemId)
				.IsRequired();

			return modelBuilder;
		}
	}
}

