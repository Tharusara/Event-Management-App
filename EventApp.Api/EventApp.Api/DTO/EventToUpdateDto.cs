using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventApp.Api.DTO
{
    public class EventToUpdateDto
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

        [Column(TypeName = "decimal(10,2)")]
        public decimal Fee { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Balance { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal HallFee { get; set; }
        public string EventStatus { get; set; }
        public string EventType { get; set; }
        public string ArrangementStyle { get; set; }
        public string ChairCoverColor { get; set; }
        public int CustomerId { get; set; }        
        public int HallId { get; set; }
    }
}
