using uHubAPI.Features.AppUserRepo.Models;
using Microsoft.EntityFrameworkCore;

namespace uHubAPI.Database.Configurations
{
	public static class UserRoleConfiguration
	{
		public static ModelBuilder UserRoleToAppUser(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserRole>()
				.HasOne(e => e.AppUser)
				.WithMany(e => e.UserRoles)
				.HasForeignKey(e => e.UserId)
				.OnDelete(DeleteBehavior.Cascade)
				.IsRequired();

			return modelBuilder;
		}
	}
}

