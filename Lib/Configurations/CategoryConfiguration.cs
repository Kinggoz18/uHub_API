using System;
using Microsoft.EntityFrameworkCore;
using uHubAPI.Models.MarketplaceModels;

namespace uHubAPI.Lib.Configurations
{
	public static class CategoryConfiguration
	{
        public static ModelBuilder CategoryToCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Categories)
                .WithOne(e => e.ParentCategory)
                .HasForeignKey(e => e.ParentCategoryId)
                .IsRequired();

            return modelBuilder;
        }
    }
}

