using System;
using System.ComponentModel.DataAnnotations;

namespace EventApp.Api.DTO
{
    public class UserforRegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "password must be between 4 and 15 characters")]
        public string Password { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string CallingName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public DateTime LastActive { get; set; }

        public UserforRegisterDto()
        {
            Created = DateTime.Now;
            LastActive = DateTime.Now;
        }
    }
}
