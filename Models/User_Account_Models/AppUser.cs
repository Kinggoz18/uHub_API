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
|   AccountId - 
|   FirstName - 
|   LastName - 
|   Email - 
|   StudentEmail - 
|   PhoneNumber - 
|   Password - 
|   VerificationStatus - 
|   ImageKey - 
|   IsLocked
|   IsBanned
|   ReportCount
|------------------------------------------------------------------
*/

namespace uHub_API.Models
{
public class AppUser
{
    [Required]
    [Key]
    public long UserId {get; set;}
    [Required]
    public string AccountId {get; set;}
    [Required]
    public string FirstName {get; set;}
    [Required]
    public string LastName {get; set;}
    [Required]
    public string Email {get; set;}
    [Required]
    public string StudentEmail {get; set;}
    [Required]
    public string PhoneNumber {get; set;}
    [Required]
    public string Password {get; set;}
    [Required]
    public string VerificationStatus {get; set;}
    [Required]
    public string ImageKey {get; set;}
    [Required]
    public bool IsLocked {get; set;}
    [Required]
    public bool IsBanned {get; set;}
    [Required]
    public int ReportCount {get; set;}
}
}