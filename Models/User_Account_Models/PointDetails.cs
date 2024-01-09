using System.ComponentModel.DataAnnotations;

namespace uHub_API.Models{
    public class PointDetail
    {
        [Required]
        public long PointId;

        [Required]
        public long DetialId;

        [Required]
        public DateTime? Date;

        [Required]
        public string? Description;
    }
}