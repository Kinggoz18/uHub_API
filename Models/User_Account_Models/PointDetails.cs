using System.ComponentModel.DataAnnotations;

namespace uHub_API.Models{
    public class PointDetail
    {
        [Required]
        public long PointId { get; set; }

        [Required]
        [Key]
        public long DetialId { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        [Required]
        public string? Description { get; set; }
    }
}