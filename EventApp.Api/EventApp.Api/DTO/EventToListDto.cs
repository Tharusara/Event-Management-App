using System;

namespace EventApp.Api.DTO
{
    public class EventToListDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime Tocreation { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int GuestCount { get; set; }
        public string VipDetails { get; set; }
        public string FunctionboardDetails { get; set; }
        public string GuestswithSpecialneeds { get; set; }
        public decimal Fee { get; set; }
        public decimal Balance { get; set; }
        public decimal HallFee { get; set; }
        public string EventStatus { get; set; }
        public string EventType { get; set; }
        public string ArrangementStyle { get; set; }
        public string ChairCoverColor { get; set; }
    }
}
