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
    public class ServiceController : ControllerBase
    {
        private readonly IEventRepository _repo;
        private readonly IMapper _mapper;

        public ServiceController(IEventRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]UserParams userParams)
        {
            var services = await _repo.GetServices(userParams);
            var servicesToReturn = _mapper.Map<IEnumerable<ServiceToReturnDto>>(services);
            Response.AddPagination(services.CurrentPage, services.PageSize, services.TotalCount, services.TotalPages);
            return Ok(servicesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var service = await _repo.GetService(Id);
            var serviceToReturn = _mapper.Map<ServiceToReturnDto>(service);
            return Ok(serviceToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Service serviceForCreation)
        {
            if (serviceForCreation == null)
            {
                return BadRequest("Service data is null");
            }
            _repo.Add(serviceForCreation);
            serviceForCreation.CreatorId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (await _repo.SaveAll())
            {
                return Created("Service Successfully Added", serviceForCreation);
            }
            return BadRequest("Adding the Service Failed on save");
        }

        [HttpPost("{id}/addSuppliers")]
        public async Task<IActionResult> AddSupplier(int id, SupplierEditDto suppliers)
        {
            if (await _repo.GetService(id) == null)
                return NotFound();
            var selectedItems = suppliers.SupplierId;
            if (suppliers.SupplierId == null || suppliers.SupplierId.Length == 0)
                return NotFound();
            for (int i = 0; i < selectedItems.Length; i++)
            {
                var item = await _repo.GetServiceSupplier(id, selectedItems[i]);
                if (item != null)
                    continue;
                item = new ServiceSupplier
                {
                    ServiceId = id,
                    SupplierId = selectedItems[i]
                };
                _repo.Add<ServiceSupplier>(item);
            }
            if (await _repo.SaveAll())
                return Ok();
            return BadRequest(new { message = "Service already been supplied by the Supplier" });
        }

        [HttpPut("{id}/removeSuppliers")]
        public async Task<IActionResult> RemoveSupplier(int id, SupplierEditDto suppliers)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var selectedItems = suppliers.SupplierId;
            for (int i = 0; i < selectedItems.Length; i++)
            {
                var itemToDelete = await _repo.GetServiceSupplier(id, selectedItems[i]);
                if (itemToDelete != null)
                {
                    _repo.Delete(itemToDelete);
                }
            }
            if (await _repo.SaveAll())
                return Ok(new { message = "suppliers are removed from Service successfully." });
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ServiceForUpdateDto serviceForUpdate)
        {
            if (serviceForUpdate == null || id == 0)
            {
                return BadRequest();
            }
            serviceForUpdate.Id = id;
            var serviceFromRepo = await _repo.GetService(id);
            if (serviceFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(serviceForUpdate, serviceFromRepo);
            if (await _repo.SaveAll())
                return NoContent();

            return BadRequest($"Updating Service{id} failed on save");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var serviceToDelete = await _repo.GetService(id);
            if (serviceToDelete == null)
            {
                return NotFound();
            }
            _repo.Delete(serviceToDelete);
            await _repo.SaveAll();
            return Ok(new { message = "Service is removed successfully." });
        }
    }
}
