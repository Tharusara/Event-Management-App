using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventApp.Api.Models
{
    public class Employee
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
        public  Gender Gender { get; set; }
        public  CivilStatus CivilStatus { get; set; }
        public  Designation Designation { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
        public  NameTitle NameTitle { get; set; }
        public virtual User Creator { get; set; }
        public virtual int CreatorId { get; set; }
        [StringLength(255, ErrorMessage = "Maximum character count is 255")]
        public string Email { get; set; }
        public virtual ICollection<EventEmployee> EventEmployees { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }

    public enum Gender{
        Male = 1,
        Female =2,
    }
    public enum CivilStatus
    {
        Single = 1,
        Married = 2,
    }
    public enum NameTitle
    {
        Mr = 1,
        Mrs = 2,
        Miss = 3,
    }
    public enum EmployeeStatus
    {
        Unknown=0,
        Active = 1,
        Deactive = 2,
    }
    public enum Designation
    {        
        Manager = 1,
        Employee = 2,
        CEO = 3,
        VicePresident = 4,
        Director = 5,
    }
}
