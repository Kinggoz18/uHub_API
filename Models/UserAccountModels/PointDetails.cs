using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace uHubAPI.Models.UserAccountModels
{

    /*======================================================================
   | Point Detail Entity class
   |
   | Name: PointDetail.cs
   |
   | Written by: Chigozie Muonagolu - January 2024
   |
   | Purpose: Entity Class model for Point Details.
   */

    /// <summary>
    ///     Class entity for a user point even detials
    /// </summary>
    public class PointDetail : EntityBaseClass
    {
        /// <summary>
        ///     The unique idenitifer of the point detail
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id { get; set; }

        /// <summary>
        ///     The date the point event took place
        /// </summary>
        [Required]
        public required DateTime Date { get; set; }

        /// <summary>
        ///     The description/detial of the point event
        /// </summary>
        [Required]
        public required string Description { get; set; }

        /// <summary>
        ///     Foreign key to point id
        /// </summary>
        [Required]
        public required long UserPointId { get; set; }

        /// <summary>
        ///     Reference navigation to user point
        /// </summary>
        public UserPoint? UserPoint { get; set; } = null!;

    }
}