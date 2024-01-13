using System.ComponentModel.DataAnnotations;

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
        public required long UserId { get; set; }

        /// <summary>
        ///    The orders unique identifer
        /// </summary>
        [Required]
        public required string Uuid { get; set; }
    }
}