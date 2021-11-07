using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventApp.Api.DTO
{
    public class HallForUpdateDto
    {
        public HallForUpdateDto()
        {
            ImageUrls = new List<string>();
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
        public string HallStatus { get; set; }
        public string HallType { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Hourfee { get; set; }

        [Column(TypeName = "decimal(14,2)")]
        public decimal Squarefeet { get; set; }
        public IList<string> ImageUrls { get; set; }
    }
}
