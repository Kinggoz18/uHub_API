/*======================================================================
| Account Model class
|
| Name: TransactionEvent.cs
|
| Written by: Chigozie Muonagolu - December 2023
|
| Purpose: Class model for a listing TransactionEvent.
|
| Usage: TransactionEvent data model schema. Used in Services.
|
| Description of properties:
|   TransactionEventID - Transaction event unique identifier number.
|   TransactionID - Transaction unique identifier number.
|   Type - The nature of the transaction event: Authorization, Capture or Refund.
|   Amount - The value of the transaction.
|   DateCreated - Transaction timestamp.
|   Currency - The currecny of the transaction.
|   GatewayID - Payment API transaction unique identifier number.
|------------------------------------------------------------------
*/
namespace uHub_API.Models
{
    public class TransactionEvent
    {
        public int TransactionEventID {get; set;}
        public int TransactionID {get; set;}
        internal TransactionType? Type {get; set;}
        public decimal? Amount {get; set;}
        public DateTime?  DateCreated {get; set; }
        public string? Currency {get; set;}
        public string? GatewayID {get; set;}
    }
}