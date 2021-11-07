using AutoMapper;
using EventApp.Api.DTO;
using EventApp.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(IConfiguration config, IMapper mapper,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _config = config;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserforRegisterDto userforRegiserDto)
        {
            var userToCreate = _mapper.Map<User>(userforRegiserDto);
            var result = await _userManager.CreateAsync(userToCreate, userforRegiserDto.Password);
            //User For Detailed Dto
            var userToReturn = _mapper.Map<UserForDetailedDto>(userToCreate);
            if (result.Succeeded)
            {
                return CreatedAtRoute("GetUser", new { controller = "Users", id = userToReturn.Id }, userToReturn);
            }
            return BadRequest(result.Errors);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            var user = await _userManager.FindByNameAsync(userForLoginDto.Username);
            if (user==null)
            {
                return Unauthorized(new { message = "user not found!" });
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, userForLoginDto.Password, false);
            if (result.Succeeded)
            {
                var appUser = _mapper.Map<UserForListDto>(user);
                return Ok(new
                {
                    token = GenerateJwtToken(user).Result,
                    user = appUser
                });
            }
            return Unauthorized();
        }
        private async Task<string> GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
                //new Claim(ClaimTypes.GivenName,user.Gender)
            };
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            if (user.Gender != null)
            {
                claims.Add(new Claim(ClaimTypes.Gender, user.Gender));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDiscriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDiscriptor);

            return tokenHandler.WriteToken(token);
        }

        [Authorize]
        [HttpPut("password/{Id}")]
        public async Task<IActionResult> ChangePassword(int Id, Passwords passwords)
        {
            if (Id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
            var username = User.FindFirst(ClaimTypes.Name).Value;
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return Unauthorized(new { message = "user not found!" });
            }
            var result = await _userManager.ChangePasswordAsync(user,passwords.CurrentPassword,passwords.NewPassword);
            if (result.Succeeded)
            {
                return Ok(new { message = "password successfully updated!" });
            }
            return BadRequest(new { message = $"Updating User {username}'s password failed on save" }); 
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPut("passwordreset/{Id}")]
        public async Task<IActionResult> ResetPassword(string Id, Passwords password)
        {
            if(password == null)
            {
                return BadRequest(new { message = "specify a new password to reset" });
            }
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                return NotFound();
            }
            await _userManager.RemovePasswordAsync(user);
            var result = await _userManager.AddPasswordAsync(user, password.NewPassword);
            if (result.Succeeded)
            {
                return Ok(new { message = "password successfully updated!" });
            }
            return BadRequest(new { message = $"Updating User {user.UserName}'s password failed on save" });
        }
    }
}