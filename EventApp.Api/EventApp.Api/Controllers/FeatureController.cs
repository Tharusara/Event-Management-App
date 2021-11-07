using AutoMapper;
using EventApp.Api.Data;
using EventApp.Api.DTO;
using EventApp.Api.Helpers;
using EventApp.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventApp.Api.Controllers
{
    [Authorize(Policy = "NormalRoles")]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IEventRepository _repo;
        private readonly IMapper _mapper;

        public FeatureController(IEventRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]UserParams userParams)
        {
            var features = await _repo.GetFeatures(userParams);
            var featuresToReturn = _mapper.Map<IEnumerable<FeatureForReturnDto>>(features);
            Response.AddPagination(features.CurrentPage, features.PageSize, features.TotalCount, features.TotalPages);
            return Ok(featuresToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Feature featureForCreation)
        {
            if (featureForCreation == null)
            {
                return BadRequest("Feature data is null");
            }
            _repo.Add(featureForCreation);
            if (await _repo.SaveAll())
            {
                return Created("Feature Successfully created", featureForCreation);
            }
            return BadRequest("Creating the Feature Failed on save");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var featureToDelete = await _repo.GetFeature(id);
            if (featureToDelete == null)
            {
                return NotFound();
            }
            _repo.Delete(featureToDelete);
            await _repo.SaveAll();
            return Ok(new { message = "Feature is deleted successfully." });
        }
    }
}
