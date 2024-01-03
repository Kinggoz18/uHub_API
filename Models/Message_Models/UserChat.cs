
namespace uHub_API.Models
{
    public class UserChat
    {
        public int MessageID {get; set;}   
        public int AccountID {get; set;}
        public int ReceiverID   {get; set;}
        public string? MessageContent {get; set;}
        public DateTime? Timestamp {get; set;}
    }
}