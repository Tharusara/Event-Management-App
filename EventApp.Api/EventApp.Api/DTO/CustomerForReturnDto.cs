using System;

namespace EventApp.Api.DTO
{
    public class CustomerForReturnDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime Tocreation { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Contact1 { get; set; }
        public string Contact2 { get; set; }
        public string Nic { get; set; }
        public string Passport { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string CustomerType { get; set; }
        public UserForListDto Creator { get; set; }
    }
}
