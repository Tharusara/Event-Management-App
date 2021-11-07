namespace EventApp.Api.Models
{
    public class EventService
    {
        public virtual Service Service { get; set; }
        public virtual int ServiceId { get; set; }
        public virtual Event Event { get; set; }
        public virtual int EventId { get; set; }
    }
}
