using System;

namespace EventApp.Api.DTO
{
    public class UserForListDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CallingName { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
    }
}
