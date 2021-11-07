using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventApp.Api.Models
{
    public class Service
    {
        [Required]
        public int Id { get; set; }

        [StringLength(8, ErrorMessage = "Character count should be 8")]
        public string Code { get; set; }
        public DateTime Tocreation { get; set; }

        [StringLength(65535, ErrorMessage = "Maximum character count is 65535")]
        public string Description { get; set; }

        [Required]
        public string Name { get; set; }
        public string Unit { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal UnitCharge { get; set; }
        public ServiceStatus ServiceStatus { get; set; }
        public virtual User Creator { get; set; }
        public virtual int CreatorId { get; set; }
        public virtual ICollection<ServiceSupplier> ServiceSuppliers { get; set; }
        public virtual ICollection<PackageService> PackageServices { get; set; }
        public virtual ICollection<EventService> EventServices { get; set; }
    }

    public enum ServiceStatus
    {
        Off = 0,
        Inquairy = 1,
        Propect = 2,
        Tentative = 3,
        Definate = 4,
    }
}
