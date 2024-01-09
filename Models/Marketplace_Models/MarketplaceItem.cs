using System.ComponentModel.DataAnnotations;

namespace uHub_API.Models
{
    public class MarketplaceItem
    {
        [Required]
        public string Uuid {get; set;}
        [Required]
        public int ItemId { get; set; }
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
        public Condition? Condition {get; set; }
        [Required]
        public DateTime?  CreatedAt {get; set; }
        [Required]
        public DateTime? ModifiedAt {get; set; }
    }
}

