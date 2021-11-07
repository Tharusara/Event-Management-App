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
    public class PackageController : ControllerBase
    {
        private readonly IEventRepository _repo;
        private readonly IMapper _mapper;

        public PackageController(IEventRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]UserParams userParams)
        {
            var packages = await _repo.GetPackages(userParams);
            var packagesToReturn = _mapper.Map<IEnumerable<PackageToReturnDto>>(packages);
            Response.AddPagination(packages.CurrentPage, packages.PageSize, packages.TotalCount, packages.TotalPages);
            return Ok(packagesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var package = await _repo.GetPackage(Id);
            var packageToReturn = _mapper.Map<PackageToReturnDto>(package);
            return Ok(packageToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Package packageForCreation)
        {
            if (packageForCreation == null)
            {
                return BadRequest("Package data is null");
            }
            packageForCreation.CreatorId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            _repo.Add(packageForCreation);
            if (await _repo.SaveAll())
            {
                return Created("Package Successfully Added", packageForCreation);
            }
            return BadRequest("Adding the Package Failed on save");
        }

        [HttpPost("{id}/addServices")]
        public async Task<IActionResult> AddService(int id, ServiceEditDto services)
        {
            if (await _repo.GetPackage(id) == null)
                return NotFound();
            var selectedItems = services.ServiceId;
            if (services.ServiceId == null || services.ServiceId.Length == 0)
                return NotFound();
            for (int i = 0; i < selectedItems.Length; i++)
            {
                var item = await _repo.GetPackageService(id, selectedItems[i]);
                if (item != null)
                    continue;
                item = new PackageService
                {
                    PackageId = id,
                    ServiceId = selectedItems[i]
                };
                _repo.Add(item);
            }
            if (await _repo.SaveAll())
                return Ok();
            return BadRequest(new { message = "Service already been supplied by the Package" });
        }

        [HttpPut("{id}/removeServices")]
        public async Task<IActionResult> RemoveService(int id, ServiceEditDto services)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var selectedItems = services.ServiceId;
            for (int i = 0; i < selectedItems.Length; i++)
            {
                var itemToDelete = await _repo.GetPackageService(id, selectedItems[i]);
                if (itemToDelete != null)
                {
                    _repo.Delete(itemToDelete);
                }
            }
            if (await _repo.SaveAll())
                return Ok(new { message = "Services are removed from Package successfully." });
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PackageForUpdateDto packageForUpdate)
        {
            if (packageForUpdate == null || id == 0)
            {
                return BadRequest();
            }
            packageForUpdate.Id = id;
            var packageFromRepo = await _repo.GetPackage(id);
            if (packageFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(packageForUpdate, packageFromRepo);
            if (await _repo.SaveAll())
                return NoContent();

            return BadRequest($"Updating Package{id} failed on save");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var packageToDelete = await _repo.GetPackage(id);
            if (packageToDelete == null)
            {
                return NotFound();
            }
            _repo.Delete(packageToDelete);
            await _repo.SaveAll();
            return Ok(new { message = "Package is removed successfully." });
        }
    }
}
