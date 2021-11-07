using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventApp.Api.Models
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }

        [StringLength(8, ErrorMessage = "Character count should be 8")]
        public string Code { get; set; }
        public DateTime Tocreation { get; set; }

        [StringLength(65535, ErrorMessage = "Maximum character count is 65535")]
        public string Description { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Maximum character count is 10")]
        [MinLength(9, ErrorMessage = "Minimum character count is 09")]
        public string Contact1 { get; set; }
        public string Contact2 { get; set; }

        [MaxLength(12, ErrorMessage = "Maximum character count is 12")]
        [MinLength(10, ErrorMessage = "Minimum character count is 12")]
        public string Nic { get; set; }
        public string Passport { get; set; }

        [StringLength(65535, ErrorMessage = "Maximum character count is 65535")]
        public string Address { get; set; }

        [StringLength(255, ErrorMessage = "Maximum character count is 255")]
        public string Email { get; set; }
        public string Fax { get; set; }

        [Required]
        public CustomerType CustomerType { get; set; }
        public virtual User Creator { get; set; }
        public virtual int CreatorId { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
    public enum CustomerType
    {
        Company = 1,
        Person = 2,
    }
}
