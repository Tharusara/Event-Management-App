using System;

namespace EventApp.Api.DTO
{
    public class PaymentToReturnDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string ChequeNo { get; set; }
        public string ChequeBranch { get; set; }
        public string ChequeBank { get; set; }
        public string Description { get; set; }
        public DateTime ChequeDate { get; set; }
        public DateTime ToCreation { get; set; }
        public string PaymentType { get; set; }
        public string PaymentStatus { get; set; }
        public EventToListDto Event { get; set; }
    }
}
