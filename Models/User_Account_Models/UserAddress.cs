namespace uHub_API.Models
{
    public class UserAddress
    {
        public int? AddressID;
        public int? AccountID;
        public string? UnitNumber { get; set; }
        //NOTE: This field is for calgary residents. Comment it out when required. 
        //public string? CivicNumber { get; set; }
        public string? StreetName {get; set; }
        public string? City {get; set; }
        public string? Province {get; set; }
        public string? PostalCode{get; set; }
    }
}