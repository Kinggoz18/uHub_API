using System.ComponentModel.DataAnnotations;
using uHubAPI.Models.MarketplaceModels;

namespace uHubAPI.Models.UserAccountModels
{
    /*======================================================================
    | Wishlist Entity class
    |
    | Name: Wishlist.cs
    |
    | Written by: Chigozie Muonagolu - January 2023
    |      
    | Purpose: Class enity for users Wishlist.
    |
    | Usage: Used in database context, service and controller classes that require it.   
    |
    |------------------------------------------------------------------ 
    */

    /// <summary>
    ///    Entity class for a users Wishlist
    /// </summary>
    public class Wishlist : EntityBaseClass
    {
        /// <summary>
        ///    Unique identifier for a wishlist
        /// </summary>
        [Key]
        [Required]
        public required override long Id { get; set; }

        /// <summary>
        ///   Foreign key for AppUser
        /// </summary>
        [Required]
        public required long AppUserId { get; set; }

        /// <summary>
        ///     Reference navigation for an app user
        /// </summary>
        public AppUser? AppUser { get; set; }

        /// <summary>
        ///    Principal navigation for a marketplace item
        /// </summary>
        public ICollection<MarketplaceItem> MarketplaceItem { get; set; } = new List<MarketplaceItem>();

}
}

