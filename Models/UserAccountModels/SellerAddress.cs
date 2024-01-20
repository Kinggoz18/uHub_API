using System.ComponentModel.DataAnnotations;
using uHubAPI.Models.MarketplaceModels;

namespace uHubAPI.Models.UserAccountModels
{
    /*======================================================================
    | Point Seller Address class
    |
    | Name: SellerAddress.cs
    |
    | Written by: Chigozie Muonagolu - January 2024
    |
    | Purpose: Entity Class model for Seller Address.
    */
    /// <summary>
    ///     Class entity for a sellers address
    /// </summary>
    public class SellerAddress : EntityBaseClass
    {
        /// <summary>
        ///     Sellers address unique identifier
        /// </summary>
        [Key]
        [Required]
        public override required long Id { get; set; }

        /// <summary>
        ///     The city of the address
        /// </summary>
        [Required]
        public required string City {get; set;}

        /// <summary>
        ///     The province of the address
        /// </summary>
        [Required]
        public required string Province {get; set;}

        /// <summary>
        ///     The postal code of the address
        /// </summary>
        [Required]
        public required string Postcode {get; set;}

        /// <summary>
        ///     The country of the address
        /// </summary>
        [Required]
        public required string Country {get; set;}

        /// <summary>
        ///    The street number and name
        /// </summary>
        [Required]
        public required string StreetInfo {get; set;}

        /// <summary>
        ///     App user foreign key
        /// </summary>
        [Required]
        public required long AppUserId { get; set; }

        /// <summary>
        ///     Reference navigation to app user
        /// </summary>
        public AppUser? AppUser { get; set; }

         /// <summary>
        ///     Principal navigation to Marketplace item
        /// </summary>
        public ICollection<MarketplaceItem> MarketplaceItem { get; } = new List<MarketplaceItem>();
    }
}