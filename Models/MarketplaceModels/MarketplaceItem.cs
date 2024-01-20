using uHubAPI.Models.UserAccountModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace uHubAPI.Models.MarketplaceModels
{
    /*======================================================================
    | Marketplace Item Entity class
    |
    | Name: MarketplaceItem.cs
    |
    | Written by: Chigozie Muonagolu - January 2023
    |      
    | Purpose: Class enity for MarketplaceItem.
    |
    | Usage: Used in database context, service and controller classes that require it.   
    |
    |------------------------------------------------------------------ 
    */
    /// <summary>
    /// Entity class for a Marketplace Item
    /// </summary>

    public class MarketplaceItem : EntityBaseClass
    {
        /// <summary>
        ///     The unique identifier for the Marketplace Item
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new Guid Id { get; set; }

        /// <summary>
        /// The sellers unique identifier for the Marketplace Item
        /// </summary>
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public Guid MarketplaceItemUId { get; set; }

        /// <summary>
        /// The title of the Marketplace item
        /// </summary>
        [Required]
        public required string Name {get; set; }

        /// <summary>
        /// The summary/description of the Marketplace item
        /// </summary>
        [Required]
        public required string Description {get; set; }

        /// <summary>
        /// The price of the Marketplace item
        /// </summary>
        [Required]
        public required decimal Price {get; set; }

        /// <summary>
        /// The defulat image key of the Marketplace item
        /// </summary>
        [Required]
        public required string DefaultImageKey {get; set; }

        /// <summary>
        /// Flag showing whether the marketpalce item has been sold
        /// </summary>
        [Required]
        public required bool? IsSold {get; set; }

        /// <summary>
        /// The condition of the marketplace item
        /// </summary>
        [Required]
        public required string? Condition {get; set; }

        /// <summary>
        /// The date the marketplace item was uploaded
        /// </summary>
        [Required]
        public required DateTime?  CreatedAt {get; set; }

        /// <summary>
        /// The date the marketplace item was last modified
        /// </summary>
        [Required]
        public required DateTime? ModifiedAt {get; set; }

        /// <summary>
        ///    Foregin key to sellers address
        /// </summary>
        [Required]
        public required long SellerAddressId { get; set; }

        /// <summary>
        ///     Reference navigation to sellers address
        /// </summary>
        public SellerAddress? SellerAddress { get; set; } = null!;

        /// <summary>
        ///     Forgien Key for a wishlist
        /// </summary>
        public long WishlistId { get; set; } = 0;

        /// <summary>
        ///     Reference navigation for a wishlist
        /// </summary>
        public Wishlist? Wishlist { get; set; } = null!;

        /// <summary>
        ///     Principal navigation for a wishlist
        /// </summary>
        public ICollection<MarketplaceItemImage>? MarketplaceItemImage { get; } = new List<MarketplaceItemImage>();

        /// <summary>
        ///     Foreign key to a category
        /// </summary>
        [Required]
        public required long CategoryId { get; set; }

        /// <summary>
        ///     The category identifier associated with a Marketplace Item
        /// </summary>
        [Required]
        public Category? Category { get; set; }

        /// <summary>
        ///     Principal navigation to OrderHistory
        /// </summary>
        public OrderHistory? OrderHistory { get; set; }
    }
}

