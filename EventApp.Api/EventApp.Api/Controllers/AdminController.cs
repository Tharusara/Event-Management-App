using EventApp.Api.Data;
using EventApp.Api.DTO;
using EventApp.Api.Helpers;
using EventApp.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EventApp.Api.Controllers
{
    [Authorize(Policy = "RequireAdminRole")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly EventDbContext _context;
        private readonly UserManager<User> _userManager;

        public AdminController(EventDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //[Authorize(Policy = "RequireAdminRole")] /api/admin/userswithroles
        [HttpGet("userswithroles")]
        public async Task<IActionResult> GetUsersWithRoles([FromQuery]UserParams userParams)
        {
            try
            {
                var userList = _context.Users
                .OrderBy(x => x.UserName)
                .Select(user => new
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Roles = (from userRole in user.UserRoles
                             join role in _context.Roles
                             on userRole.RoleId
                             equals role.Id
                             select role.Name).ToList()
                }).AsQueryable();
                //if (userParams.Roles != null)
                //{
                //    //userList = userList.Where(u => u.Roles[0].Equals(userParams.Roles));
                //    userList = userList.Where(u => u.Roles[0] == userParams.Roles);
                //}
                if (userParams.Name != null)
                {
                    userList = userList.Where(u => u.UserName.Contains(userParams.Name));
                }
                if (userParams.Id != 0)
                {
                    userList = userList.Where(u => u.Id.Equals(userParams.Id));
                }

                return Ok(userList);
            }
            catch (Exception)
            {
                var roles = await _context.Roles.ToListAsync();
                return Ok(roles);
            }
        }

        //[Authorize(Policy = "RequireAdminRole")]
        [HttpPost("editRoles/{userName}")]
        public async Task<IActionResult> EditRoles(string userName, RoleEditDto roleEditDto)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var userRoles = await _userManager.GetRolesAsync(user);
            var selectedRoles = roleEditDto.RoleNames;
            selectedRoles = selectedRoles ?? new string[] { };
            var result = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));

            if (!result.Succeeded)
                return BadRequest("failed to add to roles");

            result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));

            if (!result.Succeeded)
                return BadRequest("failed to remove the roles");

            return Ok(await _userManager.GetRolesAsync(user));
        }
    }
}