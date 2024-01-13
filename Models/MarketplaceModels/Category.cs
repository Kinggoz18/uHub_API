using System.ComponentModel.DataAnnotations;

namespace uHubAPI.Models.MarketplaceModels
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
    ///     Class entity for a marketpalce Category
    /// </summary>

    public class Category : EntityBaseClass
    {
        /// <summary>
        ///    The category unique identifer
        /// </summary>
        [Key]
        [Required]
        public override required long Id { get; set; }

        /// <summary>
        ///     The name of the category
        /// </summary>
        [Required]
        public required string Name {get; set; }

        /// <summary>
        ///     The unique identifer of the parent category. May be null (empty).
        /// </summary>
        public long ParentCategoryId {get; set;}
    }
}