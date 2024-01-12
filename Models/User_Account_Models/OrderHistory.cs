using System.ComponentModel.DataAnnotations;

namespace uHub_API.Models
{
    public class OrderHistory
    {
        [Required]
        [Key]
        public long OrderId { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public string Uuid { get; set; }
    }
}