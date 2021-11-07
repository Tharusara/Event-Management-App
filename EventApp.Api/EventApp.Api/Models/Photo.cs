using System.ComponentModel.DataAnnotations;

namespace EventApp.Api.Models
{
    public class Photo
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Filename { get; set; }
        public virtual int? HallId { get; set; }
        public virtual Hall Hall { get; set; }
        public virtual int? ItemId { get; set; }
        public virtual Item Item { get; set; }
        public virtual int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
