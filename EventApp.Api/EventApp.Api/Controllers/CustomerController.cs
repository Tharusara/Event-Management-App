using AutoMapper;
using EventApp.Api.Data;
using EventApp.Api.DTO;
using EventApp.Api.Helpers;
using EventApp.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EventApp.Api.Controllers
{
    [Authorize(Policy = "NormalRoles")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IEventRepository _repo;
        private readonly IMapper _mapper;

        public CustomerController(IEventRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]UserParams userParams)
        {
            var customers = await _repo.GetCustomers(userParams);
            var customersToReturn = _mapper.Map<IEnumerable<CustomerForReturnDto>>(customers);
            Response.AddPagination(customers.CurrentPage, customers.PageSize, customers.TotalCount, customers.TotalPages);
            return Ok(customersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var customer = await _repo.GetCustomer(Id);
            var customerToReturn = _mapper.Map<CustomerForReturnDto>(customer);
            return Ok(customerToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customerForCreation)
        {
            if (customerForCreation == null)
            {
                return BadRequest("customer data is null");
            }
            customerForCreation.CreatorId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            _repo.Add(customerForCreation);
            if (await _repo.SaveAll())
            {
                return Created("Successfully created", customerForCreation);
            }
            return BadRequest("Creating the customer Failed on save");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CustomerForUpdateDto customerForUpdate)
        {
            if (customerForUpdate == null || id == 0)
            {
                return BadRequest();
            }
            customerForUpdate.Id = id;
            var customerFromRepo = await _repo.GetCustomer(id);
            if (customerFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(customerForUpdate, customerFromRepo);
            if (await _repo.SaveAll())
                return NoContent();

            return BadRequest($"Updating Customer{id} failed on save");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var cusToDelete = await _repo.GetCustomer(id);
            if (cusToDelete == null)
            {
                return NotFound();
            }
            _repo.Delete(cusToDelete);
            await _repo.SaveAll();
            return Ok(new { message = "Customer is deleted successfully." });
        }
    }
}
