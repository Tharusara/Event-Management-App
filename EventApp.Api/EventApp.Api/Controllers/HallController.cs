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
    public class HallController : ControllerBase
    {
        private readonly IEventRepository _repo;
        private readonly IMapper _mapper;

        public HallController(IEventRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]UserParams userParams)
        {
            var halls = await _repo.GetHalls(userParams);
            var hallsToReturn = _mapper.Map<IEnumerable<HallToReturnDto>>(halls);
            Response.AddPagination(halls.CurrentPage, halls.PageSize, halls.TotalCount, halls.TotalPages);
            return Ok(hallsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var hall = await _repo.GetHall(Id);
            var hallToReturn = _mapper.Map<HallToReturnDto>(hall);
            return Ok(hallToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Hall hallForCreation)
        {
            if (hallForCreation == null)
            {
                return BadRequest("Hall data is null");
            }
            hallForCreation.CreatorId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            _repo.Add(hallForCreation);
            if (await _repo.SaveAll())
            {
                return Created("Hall Successfully Added", hallForCreation);
            }
            return BadRequest("Adding the Hall Failed on save");
        }

        [HttpPost("{id}/addFeatures")]
        public async Task<IActionResult> AddFeatures(int id, FeatureEditDto features)
        {
            if (await _repo.GetHall(id) == null)
                return NotFound();
            var selectedItems = features.FeatureId;
            if (features.FeatureId == null || features.FeatureId.Length == 0)
                return NotFound();
            for (int i = 0; i < selectedItems.Length; i++)
            {
                var item = await _repo.GetHallFeature(id, selectedItems[i]);
                if (item != null)
                    continue;
                item = new HallFeature
                {
                    HallId = id,
                    FeatureId = selectedItems[i]
                };
                _repo.Add(item);
            }
            if (await _repo.SaveAll())
                return Ok();
            return BadRequest(new { message = "Hall already has this feature" });
        }

        [HttpPut("{id}/removeFeatures")]
        public async Task<IActionResult> RemoveFeatures(int id, FeatureEditDto features)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var selectedItems = features.FeatureId;
            for (int i = 0; i < selectedItems.Length; i++)
            {
                var itemToDelete = await _repo.GetHallFeature(id, selectedItems[i]);
                if (itemToDelete != null)
                {
                    _repo.Delete(itemToDelete);
                }
            }
            if (await _repo.SaveAll())
                return Ok(new { message = "features are removed from hall successfully." });
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, HallForUpdateDto hallForUpdate)
        {
            if (hallForUpdate == null || id == 0)
            {
                return BadRequest();
            }
            hallForUpdate.Id = id;
            var hallFromRepo = await _repo.GetHall(id);
            if (hallFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(hallForUpdate, hallFromRepo);
            if (await _repo.SaveAll())
                return NoContent();

            return BadRequest($"Updating Hall{id} failed on save");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var hallToDelete = await _repo.GetHall(id);
            if (hallToDelete == null)
            {
                return NotFound();
            }
            _repo.Delete(hallToDelete);
            await _repo.SaveAll();
            return Ok(new { message = "Hall is removed successfully." });
        }
    }
}
