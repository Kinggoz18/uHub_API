/*======================================================================
| VerificationStatus enum
|
| Name: VerificationStatus.cs
|
| Written by: Chigozie Muonagolu - December 2023
|
| Purpose: Enum to hold the Verification status labels.
|
| Usage: Used in the StudentAccount and Account class model.
|
| Description of properties: None.
| 
|------------------------------------------------------------------
*/
namespace uHub_API.Models
{
    public enum VerificationStatus
{
    Verified,
    Pending,
    Unverified
}
}