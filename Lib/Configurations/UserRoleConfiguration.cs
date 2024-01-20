using Microsoft.EntityFrameworkCore;
using uHubAPI.Models.UserAccountModels;

namespace uHubAPI.Lib.Configurations
{
    /// <summary>
    ///     Extenstion class to add one-to-many configuration between an AppUser and UserRole
    /// </summary>
    public static class UserRoleConfiguration
    {

        public static ModelBuilder UserRoleToAppUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasOne(e => e.AppUser)
                .WithMany(e => e.UserRole)
                .HasForeignKey(e => e.AppUserId)
                .IsRequired();

            return modelBuilder;
        }
    }
}

