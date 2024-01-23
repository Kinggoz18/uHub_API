using System;
using Microsoft.EntityFrameworkCore;
using uHubAPI.BaseModel.UserAccountModels;
using uHubAPI.Database.Configurations;
using uHubAPI.Features.AppUserRepo.Models;
using uHubAPI.Features.MarketplaceRepo.Models;
using uHubAPI.Features.OrderHistoryRepo.Models;
using uHubAPI.Features.SellersAddressRepo.Models;
using uHubAPI.Features.UserPointsRepo.Models;
using uHubAPI.Features.WishlistRepo.Models;


namespace uHubAPI.Database.DBContext
{
    /// <summary>
    /// Database context of the application
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //Properties for account management entities
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
       
        // Properties for marketplace entities

        /// <summary>
        /// Applies configurations to account management models when creating them
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Apply relationship configurations
            modelBuilder
                .UserRoleToAppUser();

            base.OnModelCreating(modelBuilder);
        }
    }

}

