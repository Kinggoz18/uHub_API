using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id { get; set; }

        /// <summary>
        ///     The name of the category
        /// </summary>
        [Required]
        public required string Name {get; set; }

        /// <summary>
        ///     The unique identifer of the parent category. May be null (empty).
        /// </summary>
        public long ParentCategoryId {get; set;}

        /// <summary>
        ///     Principal navigation to MarketplaceItem
        /// </summary>
        public ICollection<MarketplaceItem> MarketplaceItem { get; set; } = new List<MarketplaceItem>();

        /// <summary>
        ///  Reference navigation to category
        /// </summary>
        public Category? ParentCategory { get; set; } = null!;

        /// <summary>
        ///     Principal navigation to category
        /// </summary>
        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}