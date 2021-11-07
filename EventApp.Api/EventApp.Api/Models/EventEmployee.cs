namespace EventApp.Api.Models
{
    public class EventEmployee
    {
        public virtual Employee Employee { get; set; }
        public virtual int EmployeeId { get; set; }
        public virtual Event Event { get; set; }
        public virtual int EventId { get; set; }
    }
}
