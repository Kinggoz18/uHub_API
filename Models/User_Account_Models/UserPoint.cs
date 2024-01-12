using System.ComponentModel.DataAnnotations;

/*======================================================================
| Account Model class
|
| Name: Account.cs
|
| Written by: Chigozie Muonagolu - December 2023
|
| Purpose: Class model for a listing 1.
|
| Usage: Account data model schema. Used in Services.
|
| Description of properties:
|   UserId - Account unique identifier number.
|   PointID - 
|   UserPoints - 
|------------------------------------------------------------------
*/

namespace uHub_API.Models
{
    public class UserPoint
    {
        [Required]
        public long UserId {get; set;}
        [Required]
        [Key]
        public string PointID {get; set;}
        [Required]
        public string UserPoints {get; set;}
    }
}