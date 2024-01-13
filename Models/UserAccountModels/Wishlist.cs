using System.ComponentModel.DataAnnotations;


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
        ///    Identifier for the user the wish list is associated with 
        /// </summary>
        [Required]
        public required long UserId { get; set; }

        /// <summary>
        ///    Identifier for the marktplace item the list is associated with 
        /// </summary>
        [Required]
        public required long MarketplaceId { get; set; }

}
}

