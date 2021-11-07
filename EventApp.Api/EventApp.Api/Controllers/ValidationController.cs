using EventApp.Api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EventApp.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationController : ControllerBase
    {
        private readonly EventDbContext _context;

        public ValidationController(EventDbContext context)
        {
            _context = context;
        }

        [HttpGet("employeeNic/{nic}")]
        public async Task<IActionResult> FindNic(string nic)
        {
            var employee = await _context.Employees
                   .FirstOrDefaultAsync(u => u.Nic == nic);
            if(employee == null)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet("employeeName/{name}")]
        public async Task<IActionResult> FindUName(string name)
        {
            var employee = await _context.Employees
                   .FirstOrDefaultAsync(u => u.FullName == name);
            if (employee == null)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet("employeeCName/{callingname}")]
        public async Task<IActionResult> FindCName(string callingname)
        {
            var employee = await _context.Employees
                   .FirstOrDefaultAsync(u => u.CallingName == callingname);
            if (employee == null)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet("employeeMobile/{mobile}")]
        public async Task<IActionResult> FindMobile(string mobile)
        {
            var employee = await _context.Employees
                   .FirstOrDefaultAsync(u => u.Mobile == mobile);
            if (employee == null)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet("employeeEmail/{email}")]
        public async Task<IActionResult> FindEmail(string email)
        {
            var employee = await _context.Employees
                   .FirstOrDefaultAsync(u => u.Email == email);
            if (employee == null)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet("eventtitle/{title}")]
        public async Task<IActionResult> FindTitle(string title)
        {
            var events = await _context.Events
                   .FirstOrDefaultAsync(u => u.Title == title);
            if (events == null)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet("eventdate/{date}")]
        public async Task<IActionResult> FindStartDate(DateTime date)
        {
            var events = await _context.Events
                   .FirstOrDefaultAsync(u => u.Start.Date == date);
            if (events == null)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet("eventEdate/{date}")]
        public async Task<IActionResult> FindEndDate(DateTime date)
        {
            var events = await _context.Events
                   .FirstOrDefaultAsync(u => u.End.Date == date);
            if (events == null)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet("hall/{name}")]
        public async Task<IActionResult> FindHallName(string name)
        {
            var hall = await _context.Halls
                   .FirstOrDefaultAsync(u => u.Name == name);
            if (hall == null)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet("customername/{name}")]
        public async Task<IActionResult> FindCusName(string name)
        {
            var customer = await _context.Customers
                   .FirstOrDefaultAsync(u => u.Name == name);
            if (customer == null)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet("customernic/{nic}")]
        public async Task<IActionResult> FindCusNic(string nic)
        {
            var customer = await _context.Customers
                   .FirstOrDefaultAsync(u => u.Nic == nic);
            if (customer == null)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet("customerpassport/{passport}")]
        public async Task<IActionResult> FindCusPassport(string passport)
        {
            var customer = await _context.Customers
                   .FirstOrDefaultAsync(u => u.Passport == passport);
            if (customer == null)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet("customermobile/{mobile}")]
        public async Task<IActionResult> FindCusMobile(string mobile)
        {
            var customer = await _context.Customers
                   .FirstOrDefaultAsync(u => u.Contact1 == mobile);
            if (customer == null)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet("customeremail/{email}")]
        public async Task<IActionResult> FindCusEmail(string email)
        {
            var customer = await _context.Customers
                   .FirstOrDefaultAsync(u => u.Email == email);
            if (customer == null)
            {
                return Ok(true);
            }
            return Ok(false);
        }
        [AllowAnonymous]
        [HttpGet("username/{name}")]
        public async Task<IActionResult> FindUserName(string name)
        {
            var user = await _context.Users
                   .FirstOrDefaultAsync(u => u.UserName == name);
            if (user == null)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [AllowAnonymous]
        [HttpGet("usercallingname/{cname}")]
        public async Task<IActionResult> FindCallingName(string cname)
        {
            var user = await _context.Users
                   .FirstOrDefaultAsync(u => u.CallingName == cname);
            if (user == null)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet("suppliername/{name}")]
        public async Task<IActionResult> FindSupName(string name)
        {
            var supplier = await _context.Suppliers
                   .FirstOrDefaultAsync(u => u.Name == name);
            if (supplier == null)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet("suppliernic/{nic}")]
        public async Task<IActionResult> FindSupNic(string nic)
        {
            var supplier = await _context.Suppliers
                   .FirstOrDefaultAsync(u => u.Nic == nic);
            if (supplier == null)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet("supplierpassport/{passport}")]
        public async Task<IActionResult> FindSupPassport(string passport)
        {
            var supplier = await _context.Suppliers
                   .FirstOrDefaultAsync(u => u.Passport == passport);
            if (supplier == null)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet("suppliermobile/{mobile}")]
        public async Task<IActionResult> FindSupMobile(string mobile)
        {
            var supplier = await _context.Suppliers
                   .FirstOrDefaultAsync(u => u.Contact1 == mobile);
            if (supplier == null)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet("supplieremail/{email}")]
        public async Task<IActionResult> FindSupEmail(string email)
        {
            var supplier = await _context.Suppliers
                   .FirstOrDefaultAsync(u => u.Email == email);
            if (supplier == null)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet("package/{name}")]
        public async Task<IActionResult> FindPackageName(string name)
        {
            var package = await _context.Packages
                   .FirstOrDefaultAsync(u => u.Name == name);
            if (package == null)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet("item/{name}")]
        public async Task<IActionResult> FindItemName(string name)
        {
            var item = await _context.Items
                   .FirstOrDefaultAsync(u => u.Name == name);
            if (item == null)
            {
                return Ok(true);
            }
            return Ok(false);
        }
    }
}
