using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id { get; set; }

        /// <summary>
        ///     Foreign key to App user 
        /// </summary>
        [Required]
        public required long AppUserId { get; set; }

        /// <summary>
        ///     Reference navigation to app user
        /// </summary>
        public AppUser? AppUser { get; set; } = null!;

        /// <summary>
        ///     Foregin key for marketplace item uuid
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Guid MarketplaceItemId { get; set; }

        /// <summary>
        ///     Reference navigation to MarketplaceItem
        /// </summary>
        public MarketplaceItem? MarketplaceItem { get; set; } = null!;
    }
}