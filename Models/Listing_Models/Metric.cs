/*======================================================================
| Account Model class
|
| Name: Metric.cs
|
| Written by: Chigozie Muonagolu - December 2023
|
| Purpose: Class model for a listing metric.
|
| Usage: Used in Listing.cs to track listings metrics.
|
| Description of properties:
| argv[1] - number if random number pairs to generate
|
|------------------------------------------------------------------
*/
namespace uHub_API.Models
{

    public class Metric
    {
        public Listing? ListingID {get; set;}
        public int? Likes {get; set; }
        public int? Impression {get; set; } // How long the user spends on the listing
        public int? Views {get; set; }  //The number of clicks every hour by the same user on the listing
        public string? Saves {get; set; }
        public string? Shares {get; set; }
        public string? Weight {get; set; }  //The normalized z-score total of all the fields.
    }
}