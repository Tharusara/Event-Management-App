using AutoMapper;
using EventApp.Api.Data;
using EventApp.Api.DTO;
using EventApp.Api.Helpers;
using EventApp.Api.Models;
using EventApp.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EventApp.Api.Controllers
{
    [Authorize(Policy = "ModeratorRole")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEventRepository _repo;
        private readonly IMapper _mapper;
        private readonly IFileUploadService _fileUploadService;

        public EmployeeController(IEventRepository repo, IMapper mapper, IFileUploadService fileUploadService)
        {
            _repo = repo;
            _mapper = mapper;
            _fileUploadService = fileUploadService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]UserParams userParams)
        {
            var employees = await _repo.GetEmployees(userParams);
            var employeesToReturn = _mapper.Map<IEnumerable<EmployeeForReturnDto>>(employees);
            Response.AddPagination(employees.CurrentPage, employees.PageSize, employees.TotalCount, employees.TotalPages);
            return Ok(employeesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var employee = await _repo.GetEmployee(Id);
            var employeeToReturn = _mapper.Map<EmployeeForReturnDto>(employee);
            return Ok(employeeToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee EmployeeForCreation)
        {
            if (EmployeeForCreation == null)
            {
                return BadRequest("employee data is null");
            }
            EmployeeForCreation.CreatorId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            _repo.Add(EmployeeForCreation);
            if (await _repo.SaveAll())
            {
                return Created("Successfully created", EmployeeForCreation);
            }
            return BadRequest("Creating the employee Failed on save");
        }

        [HttpPost("{id}/addEvents")]
        public async Task<IActionResult> AddEvents(int id, EventEditDto events)
        {
            if (await _repo.GetEmployee(id) == null)
                return NotFound();
            var selectedItems = events.EventId;
            if (events.EventId == null || events.EventId.Length == 0)
                return NotFound();
            for (int i = 0; i < selectedItems.Length; i++)
            {
                var item = await _repo.GetEventEmployee(id, selectedItems[i]);
                if (item != null)
                    continue;
                item = new EventEmployee
                {
                    EmployeeId = id,
                    EventId = selectedItems[i]
                };
                _repo.Add(item);
            }
            if (await _repo.SaveAll())
                return Ok();
            return BadRequest(new { message = "Employee is already in this Event" });
        }

        [HttpPut("{id}/removeEvents")]
        public async Task<IActionResult> RemoveEvents(int id, EventEditDto events)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var selectedItems = events.EventId;
            for (int i = 0; i < selectedItems.Length; i++)
            {
                var itemToDelete = await _repo.GetEventEmployee(id, selectedItems[i]);
                if (itemToDelete != null)
                {
                    _repo.Delete(itemToDelete);
                }
            }
            if (await _repo.SaveAll())
                return Ok(new { message = "Events are removed from Employee successfully." });
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EmployeeForUpdateDto employeeForUpdate)
        {
            if (employeeForUpdate == null || id == 0)
            {
                return BadRequest();
            }
            employeeForUpdate.Id = id;
            var employeeFromRepo = await _repo.GetEmployee(id);
            if (employeeFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(employeeForUpdate, employeeFromRepo);
            if (await _repo.SaveAll())
                return NoContent();

            return BadRequest($"Updating Employee{id} failed on save");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var empToDelete = await _repo.GetEmployee(id);
            if (empToDelete == null)
            {
                return NotFound();
            }
            _fileUploadService.RemoveExistingImagesFromStorage(empToDelete.Photos.ToList());
            empToDelete.Photos.Clear();
            _repo.Delete(empToDelete);
            if (await _repo.SaveAll())
            {
                return Ok(new { message = "Employee is deleted successfully." });
            }
            return BadRequest("Could not remove the employee");
        }
    }
}
