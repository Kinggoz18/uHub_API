using Microsoft.EntityFrameworkCore;
using uHubAPI.Models;

namespace uHubAPI.Lib
{
    /// <summary>
    /// Extension class for the ModelBuilder class
    /// </summary>
    public static class ModelBuilderExtensions
    {
        /// <summary>
        ///     Sets the seed for all database item id to begin from 1000.
        /// </summary>
        /// <typeparam name="T">An object that inherits from EntityBaseClass class</typeparam>
        /// <param name="modelBuilder"></param>
        /// <returns></returns>
        public static ModelBuilder ConfigureIdentityColumns<T>(this ModelBuilder modelBuilder) where T : EntityBaseClass
        {
            modelBuilder.Entity<T>()
                .Property(x => x.Id)
                .UseIdentityColumn(seed: 1000, increment: 1);

            return modelBuilder;
        }
    }
}

