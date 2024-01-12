using System.ComponentModel.DataAnnotations;
using uHub_API.Services;

namespace uHub_API.Models
{
    public class MarketplaceItem
    {
        [Required]
        [Key]
        public int ItemId { get; set; }
        [Required]
        public string Uuid {get; set;}
        [Required]
        public int AddressId {get; set; }
        [Required]
        public string CategoryId {get; set; }
        [Required]
        public string Name {get; set; }
        [Required]
        public string Description {get; set; }
        [Required]
        public decimal Price {get; set; }
        [Required]
        public string DefaultImageKey {get; set; }
        [Required]
        public bool? IsSold {get; set; }
        [Required]
        public string? Condition {get; set; }
        [Required]
        public DateTime?  CreatedAt {get; set; }
        [Required]
        public DateTime? ModifiedAt {get; set; }
    }
}

