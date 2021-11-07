using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventApp.Api.Models
{
    public class Hall
    {
        public Hall()
        {
            Photos = new Collection<Photo>();
        }
        [Required]
        public int Id { get; set; }

        [StringLength(8, ErrorMessage = "Character count should be 8")]
        public string Code { get; set; }
        public DateTime Tocreation { get; set; }

        [StringLength(65535, ErrorMessage = "Maximum character count is 65535")]
        public string Description { get; set; }

        [Required]
        public string Name { get; set; }
        public HallStatus HallStatus { get; set; }
        public HallType HallType { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Hourfee { get; set; }

        [Column(TypeName = "decimal(14,2)")]
        public decimal Squarefeet { get; set; }
        public virtual User Creator { get; set; }
        public virtual int CreatorId { get; set; }
        public virtual ICollection<HallFeature> HallFeatures { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
    public enum HallStatus
    {
        Off = 0,
        Active = 1,
        Maintainers = 2,
    }
    public enum HallType
    {
        BallRoom = 1,
        OutDoor = 2,
        MeetingHall = 3,
        Other = 4,
    }
}
