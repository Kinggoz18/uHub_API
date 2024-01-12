using System.ComponentModel.DataAnnotations;

namespace uHub_API.Models
{
    public class MarketplaceItemImage

    {
        [Key]
        [Required]
        public long ImageId { get; set; }
        [Required]
        public long ItemId {get; set;}
        [Required]
        public long ImageKey {get; set;}
    }
}