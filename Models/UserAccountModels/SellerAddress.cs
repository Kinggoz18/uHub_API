using System.ComponentModel.DataAnnotations;

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
        ///     Sellers identifier associated with their address
        /// </summary>
        [Required]
        public required long UserId {get; set;}

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
    }
}