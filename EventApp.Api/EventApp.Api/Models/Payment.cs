using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventApp.Api.Models
{
    public class Payment
    {
        [Required]
        public int Id { get; set; }

        [StringLength(8, ErrorMessage = "Character count should be 8")]
        public string Code { get; set; }
        public DateTime Date { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [MinLength(08, ErrorMessage = "Minimum character count is 08")]
        public string ChequeNo { get; set; }

        [StringLength(65535, ErrorMessage = "Maximum character count is 65535")]
        public string ChequeBranch { get; set; }

        [MinLength(03, ErrorMessage = "Minimum character count is 03")]
        public string ChequeBank { get; set; }

        [StringLength(65535, ErrorMessage = "Maximum character count is 65535")]
        public string Description { get; set; }
        public DateTime ChequeDate { get; set; }
        public DateTime ToCreation { get; set; }
        public PaymentType PaymentType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public virtual Event Event { get; set; }
        public virtual int EventId { get; set; }
    }

    public enum PaymentType
    {
        Cash = 1,
        Cheque = 2,
    }
    public enum PaymentStatus
    {
        FullPayment = 1,
        AdvancePayment = 2,
        BalancePayment = 3,
        RefundPayment = 4,
    }
}
