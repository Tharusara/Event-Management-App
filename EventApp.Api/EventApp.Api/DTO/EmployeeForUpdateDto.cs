using System;
using System.ComponentModel.DataAnnotations;

namespace EventApp.Api.DTO
{
    public class EmployeeForUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [StringLength(8, ErrorMessage = "Character count should be 8")]
        public string Code { get; set; }

        [StringLength(255, ErrorMessage = "Maximum character count is 255")]
        public string CallingName { get; set; }

        [StringLength(255, ErrorMessage = "Maximum character count is 255")]
        public string FullName { get; set; }

        public DateTime DOBirth { get; set; }

        [Required]
        [MaxLength(12, ErrorMessage = "Maximum character count is 12")]
        [MinLength(10, ErrorMessage = "Minimum character count is 12")]
        public string Nic { get; set; }

        [StringLength(65535, ErrorMessage = "Maximum character count is 65535")]
        public string Address { get; set; }

        [MaxLength(10, ErrorMessage = "Maximum character count is 10")]
        [MinLength(9, ErrorMessage = "Minimum character count is 09")]
        public string Mobile { get; set; }

        [MaxLength(10, ErrorMessage = "Maximum character count is 10")]
        [MinLength(9, ErrorMessage = "Minimum character count is 09")]
        public string Land { get; set; }

        [StringLength(65535, ErrorMessage = "Maximum character count is 65535")]
        public string Description { get; set; }
        public DateTime Dorecruite { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime ToCreation { get; set; }
        public string Gender { get; set; }
        public string CivilStatus { get; set; }
        public string Designation { get; set; }
        public string EmployeeStatus { get; set; }
        public string NameTitle { get; set; }
        public string Creator { get; set; }
        [StringLength(255, ErrorMessage = "Maximum character count is 255")]
        public string Email { get; set; }
    }
}
