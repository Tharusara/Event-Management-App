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
    [Authorize(Policy = "NormalRoles")]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IEventRepository _repo;
        private readonly IMapper _mapper;
        private readonly IFileUploadService _fileUploadService;

        public ItemController(IEventRepository repo, IMapper mapper, IFileUploadService fileUploadService)
        {
            _repo = repo;
            _mapper = mapper;
            _fileUploadService = fileUploadService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]UserParams userParams)
        {
            var items = await _repo.GetItems(userParams);
            var itemsToReturn = _mapper.Map<IEnumerable<ItemToReturnDto>>(items);
            Response.AddPagination(items.CurrentPage, items.PageSize, items.TotalCount, items.TotalPages);
            return Ok(itemsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var item = await _repo.GetItem(Id);
            var itemToReturn = _mapper.Map<ItemToReturnDto>(item);
            return Ok(itemToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Item itemForCreation)
        {
            if (itemForCreation == null)
            {
                return BadRequest("Item data is null");
            }
            itemForCreation.CreatorId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            _repo.Add(itemForCreation);
            if (await _repo.SaveAll())
            {
                return Created("Item Successfully created", itemForCreation);
            }
            return BadRequest("Creating the Item Failed on save");
        }

        [HttpPost("{id}/addPackages")]
        public async Task<IActionResult> AddPackage(int id, PackageEditDto packages)
        {
            if (await _repo.GetItem(id) == null)
                return NotFound();
            var selectedItems = packages.PackageId;
            if (packages.PackageId == null || packages.PackageId.Length == 0)
                return NotFound();
            for (int i = 0; i < selectedItems.Length; i++)
            {
                var item = await _repo.GetPackageItem(id, selectedItems[i]);
                if (item != null)
                    continue;
                item = new PackageItem
                {
                    ItemId = id,
                    PackageId = selectedItems[i]
                };
                _repo.Add(item);
            }
            if (await _repo.SaveAll())
                return Ok();
            return BadRequest(new { message = "Item already been added in the Package" });
        }

        [HttpPut("{id}/removePackages")]
        public async Task<IActionResult> RemovePackage(int id, PackageEditDto packages)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var selectedItems = packages.PackageId;
            for (int i = 0; i < selectedItems.Length; i++)
            {
                var itemToDelete = await _repo.GetPackageItem(id, selectedItems[i]);
                if (itemToDelete != null)
                {
                    _repo.Delete(itemToDelete);
                }
            }
            if (await _repo.SaveAll())
                return Ok(new { message = "items are removed from Package successfully." });
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ItemToUpdateDto itemForUpdate)
        {
            if (itemForUpdate == null || id == 0)
            {
                return BadRequest();
            }
            itemForUpdate.Id = id;
            var itemFromRepo = await _repo.GetItem(id);
            if (itemFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(itemForUpdate, itemFromRepo);
            if (await _repo.SaveAll())
                return NoContent();

            return BadRequest($"Updating Item{id} failed on save");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var itemToDelete = await _repo.GetItem(id);
            if (itemToDelete == null)
            {
                return NotFound();
            }
            _fileUploadService.RemoveExistingImagesFromStorage(itemToDelete.Photos.ToList());
            itemToDelete.Photos.Clear();
            _repo.Delete(itemToDelete);
            if (await _repo.SaveAll())
            {
                return Ok(new { message = "Item is deleted successfully." });
            }
            return BadRequest("Could not remove the Item");
        }
    }
}
