using System.ComponentModel.DataAnnotations;

namespace uHub_API.Models
{
    public class OrderHistory
    {
        [Required]
        public long UserId;
        [Required]
        public long OrderId;
        [Required]
        public string Uuid;
    }
}