using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventApp.Api.DTO
{
    public class PackageForUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [StringLength(8, ErrorMessage = "Character count should be 8")]
        public string Code { get; set; }
        public DateTime Tocreation { get; set; }

        [StringLength(65535, ErrorMessage = "Maximum character count is 65535")]
        public string Description { get; set; }
        public int Hours { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Extrahourcost { get; set; }
        public string PackageStatus { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
