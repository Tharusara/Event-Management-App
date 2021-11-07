namespace EventApp.Api.Models
{
    public class EventItem
    {
        public virtual Item Item { get; set; }
        public virtual int ItemId { get; set; }
        public virtual Event Event { get; set; }
        public virtual int EventId { get; set; }
    }
}
