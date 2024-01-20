using System.ComponentModel.DataAnnotations;
using uHubAPI.Models.MarketplaceModels;
namespace uHubAPI.Models.UserAccountModels
{
    /*======================================================================
    | OrderHistory Entity class
    |
    | Name: OrderHistory.cs
    |
    | Written by: Chigozie Muonagolu - January 2024
    |
    | Purpose: Entity Class model for an Order history.
    */

    /// <summary>
    ///     Class entity for a users order history
    /// </summary>
    public class OrderHistory : EntityBaseClass
    {
        /// <summary>
        ///     Unique identifier for a single order/purchase 
        /// </summary>
        [Required]
        [Key]
        public override required long Id { get; set; }

        /// <summary>
        ///     The users identifer associated with the order/purchase 
        /// </summary>
        [Required]
        public required long AppUserId { get; set; }

        /// <summary>
        ///     Reference navigation to app user
        /// </summary>
        public AppUser? AppUser { get; set; }

        /// <summary>
        ///     Foregin key for marketplace item uuid
        /// </summary>
        public required long Uuid { get; set; }

        /// <summary>
        ///     Reference navigation to MarketplaceItem
        /// </summary>
        public MarketplaceItem? MarketplaceItem { get; set; }
    }
}