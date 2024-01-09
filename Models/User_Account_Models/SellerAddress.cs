using System.ComponentModel.DataAnnotations;

namespace uHub_API.Models
{
    public class SellerAddress
    {
        [Required]
        public long UserId {get; set;}
        [Required]
        public long AddressId {get; set;}
        [Required]
        public long City {get; set;}
        [Required]
        public long Province {get; set;}
        [Required]
        public long Postcode {get; set;}
        [Required]
        public long Country {get; set;}
        [Required]
        public long AddressInfo {get; set;}
    }
}