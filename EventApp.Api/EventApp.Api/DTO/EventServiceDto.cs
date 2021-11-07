using System;

namespace EventApp.Api.DTO
{
    public class EventServiceDto
    {
        public int Id { get; set; }
        public virtual ServiceToReturnDto Service { get; set; }
        public virtual int ServiceId { get; set; }
        public virtual EventToReturnDto Event { get; set; }
        public virtual int EventId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
