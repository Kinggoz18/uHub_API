using Microsoft.EntityFrameworkCore;
using uHubAPI.Models.UserAccountModels;

namespace uHubAPI.Lib.Configurations
{
	public static class UserPointConfiguration
	{
		public static ModelBuilder UserPointToAppUser(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserPoint>()
				.HasOne(e => e.AppUser)
				.WithOne(e => e.UserPoint)
				.HasForeignKey<UserPoint>(e => e.AppUserId)
				.IsRequired();
	
			return modelBuilder;
		}
    }
}

