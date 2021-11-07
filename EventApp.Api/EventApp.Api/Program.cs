using EventApp.Api.Data;
using EventApp.Api.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace EventApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var Host = CreateHostBuilder(args).Build();
            using (var Scope = Host.Services.CreateScope())
            {
                var services = Scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<EventDbContext>();
                    var userManger = services.GetRequiredService<UserManager<User>>();
                    var roleManger = services.GetRequiredService<RoleManager<Role>>();
                    context.Database.Migrate();
                    SeedData.SeedUsers(userManger, roleManger);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured during Migrations");
                }
            }
            Host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
