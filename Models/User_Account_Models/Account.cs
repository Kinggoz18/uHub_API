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
|   AccountID - Account unique identifier number.
|   FirstName - Users first name
|   LastName - Users last name.
|   Username - Users account name.
|   Password - Hashed password.
|   PhoneNumber - users primary phone number.
|   EmailAddress - users primary email address.
|   VerificationStatus - verification status of account: Verified, Pending or Unverified.
|   AddressList - List of users addresses.
|------------------------------------------------------------------
*/

namespace uHub_API.Models
{
public class Account : IAccount
{
    public int? AccountID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; } 
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? PhoneNumber { get; set; }
    public string? EmailAddress { get; set; }
    public VerificationStatus? VerificationStatus { get; set; }
    public List<UserAddress>? AddressList { get; set; }
}
}