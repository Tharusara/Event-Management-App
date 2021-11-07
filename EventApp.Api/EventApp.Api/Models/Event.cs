using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventApp.Api.Models
{
    public class Event
    {
        [Required]
        public int Id { get; set; }

        [StringLength(8, ErrorMessage = "Character count should be 8")]
        public string Code { get; set; }
        public DateTime Tocreation { get; set; }

        [StringLength(65535, ErrorMessage = "Maximum character count is 65535")]
        public string Description { get; set; }

        [Required]
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int GuestCount { get; set; }
        public string VipDetails { get; set; }
        public string FunctionboardDetails { get; set; }
        public string GuestswithSpecialneeds { get; set; }

        public virtual User Creator { get; set; }
        public virtual int CreatorId { get; set; }

        public virtual Hall Hall { get; set; }
        public virtual int? HallId { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Fee { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Balance { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal HallFee { get; set; }
        public EventStatus EventStatus { get; set; }
        public EventType EventType { get; set; }
        public ArrangementStyle ArrangementStyle { get; set; }
        public ChairCoverColor ChairCoverColor { get; set; }
        public virtual ICollection<EventService> EventServices { get; set; }
        public virtual ICollection<EventItem> EventItems { get; set; }
        public virtual ICollection<EventEmployee> EventEmployees { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual int? CustomerId { get; set; }
    }
    public enum EventStatus
    {
        Off = 0,
        Inquairy = 1,
        Propect = 2,
        Tentative = 3,
        Definate = 4,
        Cancel = 5,
    }
    public enum EventType
    {
        Wedding = 1,
        Incentive = 2,
        Meeting = 3,
        Exhibition = 4,
        Conference = 5,
        Other = 6,
    }
    public enum ArrangementStyle
    {
        TheatreStyle = 1,
        Classroom = 2,
        BoardRoomStyle = 3,
        CabaretStyle = 4,
        UshapedWithTables = 5,
        UshapedWithoutTables = 6,
    }
    public enum ChairCoverColor
    {
        White = 1,
        Cream = 2,
        Blue = 3,
        Browne = 4,
        Custom = 5,
    }
}
