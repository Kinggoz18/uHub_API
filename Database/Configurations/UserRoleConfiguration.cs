using uHubAPI.Features.AppUserRepo.Models;
using Microsoft.EntityFrameworkCore;

namespace uHubAPI.Database.Configurations
{
	/// <summary>
	/// TODO: Add summary
	/// </summary>
	public static class UserRoleConfiguration
	{
        /// <summary>
        /// TODO: Add summary
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <returns></returns>
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

