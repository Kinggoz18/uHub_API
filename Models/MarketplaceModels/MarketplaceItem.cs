using System.ComponentModel.DataAnnotations;

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
        /// The unique identifier for the Marketplace Item
        /// </summary>
        [Key]
        [Required]
        public override long Id { get; set; }

        /// <summary>
        /// The sellers unique identifier for the Marketplace Item
        /// </summary>
        [Required]
        public required string Uuid {get; set;}

        /// <summary>
        /// The base address identifier of the Marketplace item
        /// </summary>
        [Required]
        public required int AddressId {get; set; }

        /// <summary>
        /// The category identifier associated with a Marketplace Item
        /// </summary>
        [Required]
        public required string CategoryId {get; set; }

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
    }
}

