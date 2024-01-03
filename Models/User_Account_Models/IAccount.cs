/*======================================================================
| Account Model class
|
| Name: IAccount.cs
|
| Written by: Chigozie Muonagolu - December 2023
|
| Purpose: Interface for the Account class model.
|
| Usage: Used in Account, StudentAccounts and Transactions class models.
|
| Description of properties:
|   AccountID - Account unique identifier number.
|
|------------------------------------------------------------------
*/
namespace uHub_API.Models
{
    public interface IAccount
    {
        public int? AccountID { get; set; }   
    }
}