using Microsoft.EntityFrameworkCore;
using uHubAPI.Features.AppUserRepo.Models;

namespace uHubAPI.Features.AppUserRepo.Configurations
{
	
	public static class AppUserConfiguration
    {
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

