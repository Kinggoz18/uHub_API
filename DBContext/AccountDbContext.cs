using System;
using Microsoft.EntityFrameworkCore;
using uHubAPI.Models.UserAccountModels;
using uHubAPI.Lib.Configurations;

namespace uHubAPI.DBContext
{
    /// <summary>
    /// Database context of all Account related entities in the database
    /// </summary>
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options) {
        }

        //Properties for account management entities
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
        public DbSet<SellerAddress> SellerAddresses { get; set; }
        public DbSet<UserPoint> UserPoints { get; set; }
        public DbSet<PointDetail> PointDetails { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }

        /// <summary>
        /// Applies configurations to account management models when creating them
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Account management configurations

            //ID configurations
            modelBuilder.ConfigureIdentityColumns<AppUser>()
                .ConfigureIdentityColumns<UserRole>()
                .ConfigureIdentityColumns<OrderHistory>()
                .ConfigureIdentityColumns<SellerAddress>()
                .ConfigureIdentityColumns<UserPoint>()
                .ConfigureIdentityColumns<PointDetail>()
                .ConfigureIdentityColumns<Wishlist>()

            //Relationship configurations
                .UserRoleToAppUser()
                .UserPointToAppUser();

            base.OnModelCreating(modelBuilder);
        }
    }

}

