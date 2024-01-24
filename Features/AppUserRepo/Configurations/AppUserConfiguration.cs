using Microsoft.EntityFrameworkCore;
using uHubAPI.Features.AppUserRepo.Models;

namespace uHubAPI.Features.AppUserRepo.Configurations
{
    /// <summary>
    /// TODO: Add summary
    /// </summary>
    public static class AppUserConfiguration
    {
        /// <summary>
        /// TODO: Add summary
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <returns></returns>
        public static ModelBuilder AppUserIdentityColumn(this ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<AppUser>()
				.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(10000000, 1);

			return modelBuilder;
		}
	}
}

