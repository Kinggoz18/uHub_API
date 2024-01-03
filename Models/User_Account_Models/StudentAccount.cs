/*======================================================================
| Account Model class
|
| Name: StudentAccount.cs
|
| Written by: Chigozie Muonagolu - December 2023
|
| Purpose: Class model for a listing 1.
|
| Usage: Student Account data model schema. Used in Services.
|
| Description of properties:
|   AccountID - Account unique identifier number.
|   FirstName - Users first name
|   LastName - Users last name.
|   Username - Users account name.
|   Password - Hashed password.
|   PhoneNumber - users primary phone number.
|   EmailAddress - users primary email address.
|   StudentEmailAddress - Email address used to verify student.
|   VerificationStatus - verification status of account: Verified, Pending or Unverified.
|   StudentStatus - Users current status as a student: Enrolled, Graduated.
|   Address - List of users addresses.
|   School - The users institution
|   Address - 
|   AnalyticData - 
|   IsSeller - 
|------------------------------------------------------------------
*/
namespace uHub_API.Models
{
    public class StudentAccount : IAccount
    {
        public int? AccountID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; } 
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? StudentEmailAddress { get; set; }
        public VerificationStatus? VerificationStatus { get; set; }
        public StudentStatus? StudentStatus { get; set; }
        public string? School { get; set; }
        public UserAddress? Address { get; set; }
        public Analytic? AnalyticData { get; set; }
        public bool? IsSeller {get; set; }
    }
}