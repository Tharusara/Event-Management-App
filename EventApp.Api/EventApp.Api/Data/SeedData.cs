using EventApp.Api.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace EventApp.Api.Data
{
    public class SeedData
    {
        public static void SeedUsers(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            if (!userManager.Users.Any())
            {
                var userData = System.IO.File.ReadAllText("Data/SeedData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);

                // create some custom roles
                var roles = new List<Role>
                {
                    new Role{Name="Admin"},
                    new Role{Name="Manager"},
                    new Role{Name="Supervisor"},
                    new Role{Name="Employee"}
                };
                foreach (var role in roles)
                {
                    roleManager.CreateAsync(role).Wait();
                }
                foreach (var user in users)
                {
                    userManager.CreateAsync(user, "password").Wait();
                    userManager.AddToRoleAsync(user, "Employee").Wait();
                }

                // create admin user
                var adminUser = new User
                {
                    UserName = "Admin"
                };
                var results = userManager.CreateAsync(adminUser, "password").Result;
                if (results.Succeeded)
                {
                    var admin = userManager.FindByNameAsync("Admin").Result;
                    userManager.AddToRolesAsync(admin, new[] { "Admin" }).Wait();
                }
            }

        }
    }
}
