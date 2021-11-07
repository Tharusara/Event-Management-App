using System;

namespace EventApp.Api.DTO
{
    public class ServiceToReturnDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime Tocreation { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal UnitCharge { get; set; }
        public string ServiceStatus { get; set; }
        public UserForListDto Creator { get; set; }
    }
}
