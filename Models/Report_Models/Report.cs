namespace uHub_API.Models
{
    public class Report
    {
        public int ReportID {get; set;}
        public int ReporterID {get; set;}
        public int ReportedID {get; set;}
        public ReportType? ReportType {get; set;} 
        public string? Description {get; set;} 
        public DateTime? CreatedDate {get; set;} 
    }
}