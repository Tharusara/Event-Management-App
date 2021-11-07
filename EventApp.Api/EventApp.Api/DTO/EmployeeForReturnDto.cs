using System;
using System.Collections.Generic;

namespace EventApp.Api.DTO
{
    public class EmployeeForReturnDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string CallingName { get; set; }
        public string FullName { get; set; }
        public DateTime DOBirth { get; set; }
        public string Nic { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Land { get; set; }
        public string Description { get; set; }
        public DateTime Dorecruite { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime ToCreation { get; set; }
        public string Gender { get; set; }
        public string CivilStatus { get; set; }
        public string Designation { get; set; }
        public string EmployeeStatus { get; set; }
        public string NameTitle { get; set; }
        public UserForListDto Creator { get; set; }
        public string Email { get; set; }
        public ICollection<PhotosDto> Photos { get; set; }
    }
}
