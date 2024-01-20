﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using uHubAPI.DBContext;

#nullable disable

namespace uHubAPI.Migrations.MarketplaceDb
{
    [DbContext(typeof(MarketplaceDbContext))]
    [Migration("20240120173908_MarketplaceMigration")]
    partial class MarketplaceMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("uHubAPI.Models.MarketplaceModels.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ParentCategoryId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("uHubAPI.Models.MarketplaceModels.MarketplaceItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("DefaultImageKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsSold")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18, 2)");

                    b.Property<long>("SellerAddressId")
                        .HasColumnType("bigint");

                    b.Property<long>("WishlistId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SellerAddressId");

                    b.HasIndex("WishlistId");

                    b.ToTable("MarketplaceItems");
                });

            modelBuilder.Entity("uHubAPI.Models.MarketplaceModels.MarketplaceItemImage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ImageKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MarketplaceItemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MarketplaceItemId");

                    b.ToTable("MarketplaceItemImages");
                });

            modelBuilder.Entity("uHubAPI.Models.UserAccountModels.AppUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLocked")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReportCount")
                        .HasColumnType("int");

                    b.Property<string>("StudentEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VerificationStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppUser");
                });

            modelBuilder.Entity("uHubAPI.Models.UserAccountModels.OrderHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AppUserId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("MarketplaceItemId")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("MarketplaceItemId")
                        .IsUnique();

                    b.ToTable("OrderHistory");
                });

            modelBuilder.Entity("uHubAPI.Models.UserAccountModels.PointDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserPointId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserPointId");

                    b.ToTable("PointDetail");
                });

            modelBuilder.Entity("uHubAPI.Models.UserAccountModels.SellerAddress", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AppUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.ToTable("SellerAddress");
                });

            modelBuilder.Entity("uHubAPI.Models.UserAccountModels.UserPoint", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AppUserId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserPoints")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.ToTable("UserPoint");
                });

            modelBuilder.Entity("uHubAPI.Models.UserAccountModels.UserRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AppUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("uHubAPI.Models.UserAccountModels.Wishlist", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AppUserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.ToTable("Wishlist");
                });

            modelBuilder.Entity("uHubAPI.Models.MarketplaceModels.Category", b =>
                {
                    b.HasOne("uHubAPI.Models.MarketplaceModels.Category", "ParentCategory")
                        .WithMany("Categories")
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("uHubAPI.Models.MarketplaceModels.MarketplaceItem", b =>
                {
                    b.HasOne("uHubAPI.Models.MarketplaceModels.Category", "Category")
                        .WithMany("MarketplaceItem")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("uHubAPI.Models.UserAccountModels.SellerAddress", "SellerAddress")
                        .WithMany("MarketplaceItem")
                        .HasForeignKey("SellerAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("uHubAPI.Models.UserAccountModels.Wishlist", "Wishlist")
                        .WithMany("MarketplaceItem")
                        .HasForeignKey("WishlistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("SellerAddress");

                    b.Navigation("Wishlist");
                });

            modelBuilder.Entity("uHubAPI.Models.MarketplaceModels.MarketplaceItemImage", b =>
                {
                    b.HasOne("uHubAPI.Models.MarketplaceModels.MarketplaceItem", "MarketplaceItem")
                        .WithMany("MarketplaceItemImage")
                        .HasForeignKey("MarketplaceItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MarketplaceItem");
                });

            modelBuilder.Entity("uHubAPI.Models.UserAccountModels.OrderHistory", b =>
                {
                    b.HasOne("uHubAPI.Models.UserAccountModels.AppUser", "AppUser")
                        .WithMany("OrderHistory")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("uHubAPI.Models.MarketplaceModels.MarketplaceItem", "MarketplaceItem")
                        .WithOne("OrderHistory")
                        .HasForeignKey("uHubAPI.Models.UserAccountModels.OrderHistory", "MarketplaceItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("MarketplaceItem");
                });

            modelBuilder.Entity("uHubAPI.Models.UserAccountModels.PointDetail", b =>
                {
                    b.HasOne("uHubAPI.Models.UserAccountModels.UserPoint", "UserPoint")
                        .WithMany("PointDetail")
                        .HasForeignKey("UserPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserPoint");
                });

            modelBuilder.Entity("uHubAPI.Models.UserAccountModels.SellerAddress", b =>
                {
                    b.HasOne("uHubAPI.Models.UserAccountModels.AppUser", "AppUser")
                        .WithOne("SellerAddress")
                        .HasForeignKey("uHubAPI.Models.UserAccountModels.SellerAddress", "AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("uHubAPI.Models.UserAccountModels.UserPoint", b =>
                {
                    b.HasOne("uHubAPI.Models.UserAccountModels.AppUser", "AppUser")
                        .WithOne("UserPoint")
                        .HasForeignKey("uHubAPI.Models.UserAccountModels.UserPoint", "AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("uHubAPI.Models.UserAccountModels.UserRole", b =>
                {
                    b.HasOne("uHubAPI.Models.UserAccountModels.AppUser", "AppUser")
                        .WithMany("UserRole")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("uHubAPI.Models.UserAccountModels.Wishlist", b =>
                {
                    b.HasOne("uHubAPI.Models.UserAccountModels.AppUser", "AppUser")
                        .WithOne("Wishlist")
                        .HasForeignKey("uHubAPI.Models.UserAccountModels.Wishlist", "AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("uHubAPI.Models.MarketplaceModels.Category", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("MarketplaceItem");
                });

            modelBuilder.Entity("uHubAPI.Models.MarketplaceModels.MarketplaceItem", b =>
                {
                    b.Navigation("MarketplaceItemImage");

                    b.Navigation("OrderHistory");
                });

            modelBuilder.Entity("uHubAPI.Models.UserAccountModels.AppUser", b =>
                {
                    b.Navigation("OrderHistory");

                    b.Navigation("SellerAddress");

                    b.Navigation("UserPoint");

                    b.Navigation("UserRole");

                    b.Navigation("Wishlist");
                });

            modelBuilder.Entity("uHubAPI.Models.UserAccountModels.SellerAddress", b =>
                {
                    b.Navigation("MarketplaceItem");
                });

            modelBuilder.Entity("uHubAPI.Models.UserAccountModels.UserPoint", b =>
                {
                    b.Navigation("PointDetail");
                });

            modelBuilder.Entity("uHubAPI.Models.UserAccountModels.Wishlist", b =>
                {
                    b.Navigation("MarketplaceItem");
                });
#pragma warning restore 612, 618
        }
    }
}
