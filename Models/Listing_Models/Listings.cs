using Microsoft.VisualBasic;

namespace uHub_API.Models
{
    public class Listing
    {
        public int? ListingID { get; set; }
        public int? SellerID {get; set; }
        public string? Title {get; set; }
        public string? Description {get; set; }
        public decimal? Price {get; set; }
        public string? Category {get; set; }
        public string? ImageUrl {get; set; }
        public string? AvailabilityStatus {get; set; }
        public DateTime?  PostedDate {get; set; }
        public Metric? Engagement {get; set; }
    }
}