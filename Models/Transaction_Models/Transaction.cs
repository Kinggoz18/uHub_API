/*======================================================================
| Account Model class
|
| Name: Transaction.cs
|
| Written by: Chigozie Muonagolu - December 2023
|
| Purpose: Class model for a listing 1.
|
| Usage: Transaction data model schema. Used in Services.
|
| Description of properties:
|   TransactionID - Transaction unique identifier number.
|   MerchantID - Seller(student) unique identifier number.
|   CustomerID - Buyer unique identifier number.
|   ListingID - Listing unique identifier number.
|   DateCreated - Transaction timestamp.
|   Description - Brief description of what was purchased.
|   Gateway - Payment API used to process payment.
|   Method - Customer's payment method.
|------------------------------------------------------------------
*/
namespace uHub_API.Models
{
    public class Transaction
    {
        public int TransactionID {get; set;}
        public StudentAccount? MerchantID {get; set;}
        public IAccount? CustomerID {get; set;}
        public Listing? ListingID {get; set;}
        public DateTime?  DateCreated {get; set; }
        public string? Description {get; set;}
        public string? Gateway {get; set;}
        public string? Method {get; set;}

    }
}