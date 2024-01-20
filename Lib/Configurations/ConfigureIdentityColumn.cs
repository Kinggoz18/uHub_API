using Microsoft.EntityFrameworkCore;
using uHubAPI.Models;

namespace uHubAPI.Lib.Configurations
{
    /// <summary>
    /// Extension class for the ModelBuilder class
    /// </summary>
    public static class ConfigureIdentityColumn
    {
        /// <summary>
        ///     Sets the seed for all database table primary Id to begin from 1000.
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

