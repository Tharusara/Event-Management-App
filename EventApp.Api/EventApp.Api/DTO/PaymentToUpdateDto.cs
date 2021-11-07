using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventApp.Api.DTO
{
    public class PaymentToUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [StringLength(8, ErrorMessage = "Character count should be 8")]
        public string Code { get; set; }
        public DateTime Date { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [Required]
        [MinLength(08, ErrorMessage = "Minimum character count is 08")]
        public string ChequeNo { get; set; }

        [StringLength(65535, ErrorMessage = "Maximum character count is 65535")]
        public string ChequeBranch { get; set; }

        [Required]
        [MinLength(03, ErrorMessage = "Minimum character count is 03")]
        public string ChequeBank { get; set; }

        [StringLength(65535, ErrorMessage = "Maximum character count is 65535")]
        public string Description { get; set; }
        public DateTime ChequeDate { get; set; }
        public DateTime ToCreation { get; set; }
        public string PaymentType { get; set; }
        public string PaymentStatus { get; set; }
        public int EventId { get; set; }
    }
}
