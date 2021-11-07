using System;

namespace EventApp.Api.Helpers
{
    public class UserParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 5;
        public int UserId { get; set; }
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
        public string Name { get; set; }
        public string Nic { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public int Designation { get; set; }
        public int SupplierStatus { get; set; }
        public int SupplierType { get; set; }
        public int PaymentStatus { get; set; }
        public int PaymentType { get; set; }
        public int ServiceStatus { get; set; }
        public int PackageStatus { get; set; }
        public int Price { get; set; }
        public int HallStatus { get; set; }
        public int HallType { get; set; }
        public int EventType { get; set; }
        public int EventStatus { get; set; }
        public int GuestCount { get; set; }
        public int ItemStatus { get; set; }
        public string Code { get; set; }
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Roles { get; set; }
        public string ChequeNo { get; set; }
        public DateTime MinAge { get; set; }
        public DateTime MaxAge { get; set; }
    }    
}
