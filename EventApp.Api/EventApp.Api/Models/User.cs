using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace EventApp.Api.Models
{
    public class User : IdentityUser<int>
    {
        public string Gender { get; set; } //no need
        public DateTime DateOfBirth { get; set; } //no need
        public string CallingName { get; set; } //no need
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<Hall> Halls { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
