using Microsoft.EntityFrameworkCore;
using uHubAPI.Models.UserAccountModels;

namespace uHubAPI.Lib.Configurations
{
	public static class PointDetailConfiguration
	{
		public static ModelBuilder UserPointToPointDetail(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PointDetail>()
				.HasOne(e => e.UserPoint)
				.WithMany(e => e.PointDetail)
				.HasForeignKey(e => e.UserPointId)
				.IsRequired();

			return modelBuilder;
		}
	}
}

