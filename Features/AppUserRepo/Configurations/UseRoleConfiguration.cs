using Microsoft.EntityFrameworkCore;
using uHubAPI.Features.AppUserRepo.Models;

namespace uHubAPI.Features.AppUserRepo.Configurations
{
	
	public static class UseRoleConfiguration
    {
		public static ModelBuilder UserRoleIdentityColumn(this ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<UserRole>()
				.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(10000000, 1);

			return modelBuilder;
		}
	}
}

