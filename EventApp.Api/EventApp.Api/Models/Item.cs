using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventApp.Api.Models
{
    public class Item
    {
        [Required]
        public int Id { get; set; }

        [StringLength(8, ErrorMessage = "Character count should be 8")]
        public string Code { get; set; }
        public DateTime ToCreation { get; set; }

        [StringLength(65535, ErrorMessage = "Maximum character count is 65535")]
        public string Description { get; set; }

        [Required]
        public string Name { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal UnitPrice { get; set; }
        public byte[] Photo { get; set; }
        public virtual User Creator { get; set; }
        public virtual int CreatorId { get; set; }
        public ItemStatus ItemStatus { get; set; }
        public virtual ICollection<ItemSupplier> ItemSuppliers { get; set; }
        public virtual ICollection<PackageItem> PackageItems { get; set; }
        public virtual ICollection<EventItem> EventItems { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }

    public enum ItemStatus
    {
        Active = 1,
        Deactive = 2,
    }
}
