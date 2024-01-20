using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace uHubAPI.Models.MarketplaceModels
{
    /*======================================================================
    | Marketplace Item Image Entity class
    |
    | Name: MarketplaceItemImage.cs
    |
    | Written by: Chigozie Muonagolu - January 2023
    |      
    | Purpose: Class enity for MarketplaceItemImage.
    |
    | Usage: Used in database context, service and controller classes that require it.   
    |
    |------------------------------------------------------------------ 
    */
    /// <summary>
    /// Entity class for marketplace item images
    /// </summary>
    public class MarketplaceItemImage : EntityBaseClass

    {
        /// <summary>
        ///     A marketplace item image unique identifier
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id { get; set; }

        /// <summary>
        ///     The image key used to identify the marketplace item in the external storage
        /// </summary>
        [Required]
        public required string ImageKey {get; set;}

        /// <summary>
        ///     Foregin key to MarketplaceItem
        /// </summary>
        [Required]
        public required Guid MarketplaceItemId { get; set; }

        /// <summary>
        ///     Reference navigation to MarketplaceItem
        /// </summary>
        public MarketplaceItem? MarketplaceItem { get; set; } = null!;
    }
}