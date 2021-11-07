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
    public class SupplierController : ControllerBase
    {
        private readonly IEventRepository _repo;
        private readonly IMapper _mapper;

        public SupplierController(IEventRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]UserParams userParams)
        {
            var suppliers = await _repo.GetSuppliers(userParams);
            var suppliersToReturn = _mapper.Map<IEnumerable<SupplierForReturnDto>>(suppliers);
            Response.AddPagination(suppliers.CurrentPage, suppliers.PageSize, suppliers.TotalCount, suppliers.TotalPages);
            return Ok(suppliersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var supplier = await _repo.GetSupplier(Id);
            var suppliersToReturn = _mapper.Map<SupplierForReturnDto>(supplier);
            return Ok(suppliersToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Supplier supplierForCreation)
        {
            if (supplierForCreation == null)
            {
                return BadRequest("supplier data is null");
            }
            supplierForCreation.CreatorId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            _repo.Add(supplierForCreation);
            if (await _repo.SaveAll())
            {
                return Created("Successfully created", supplierForCreation);
            }
            return BadRequest("Creating the supplier Failed on save");
        }

        [HttpPost("{id}/addItems")]
        public async Task<IActionResult> AddItem(int id, ItemEditDto items)
        {
            if (await _repo.GetSupplier(id) == null)
                return NotFound();
            var selectedItems = items.ItemId;
            if (items.ItemId == null || items.ItemId.Length == 0)
                return NotFound();
            for (int i = 0; i < selectedItems.Length; i++)
            {
                var item = await _repo.GetItemSupplier(id, selectedItems[i]);
                if (item != null)
                    continue;
                item = new ItemSupplier
                {
                    SupplierId = id,
                    ItemId = selectedItems[i]
                };
                _repo.Add(item);
            }
            if (await _repo.SaveAll())
                return Ok();
            return BadRequest(new { message = "supplier already supply this items" });
        }

        [HttpPut("{id}/removeItems")]
        public async Task<IActionResult> RemoveItem(int id, ItemEditDto items)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var selectedItems = items.ItemId;
            for (int i = 0; i < selectedItems.Length; i++)
            {
                var itemToDelete = await _repo.GetItemSupplier(id, selectedItems[i]);
                if (itemToDelete != null)
                {
                    _repo.Delete(itemToDelete);
                }
            }
            if (await _repo.SaveAll())
                return Ok(new { message = "items are removed from suppliers successfully." });
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SupplierForUpdateDto supplierForUpdate)
        {
            if (supplierForUpdate == null || id == 0)
            {
                return BadRequest();
            }
            supplierForUpdate.Id = id;
            var supplierFromRepo = await _repo.GetSupplier(id);
            if (supplierFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(supplierForUpdate, supplierFromRepo);
            if (await _repo.SaveAll())
                return NoContent();

            return BadRequest($"Updating Supplier{id} failed on save");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var supplierToDelete = await _repo.GetSupplier(id);
            if (supplierToDelete == null)
            {
                return NotFound();
            }
            _repo.Delete(supplierToDelete);
            await _repo.SaveAll();
            return Ok(new { message = "Supplier is deleted successfully." });
        }
    }
}
