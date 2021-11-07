using AutoMapper;
using EventApp.Api.Data;
using EventApp.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventApp.Api.Controllers
{
    [Authorize(Policy = "NormalRoles")]
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IEventRepository _repo;
        private readonly IMapper _mapper;
        private readonly IFileUploadService _fileUploadService;

        public PhotosController(IEventRepository repo, IMapper mapper, IFileUploadService fileUploadService)
        {
            _repo = repo;
            _mapper = mapper;
            _fileUploadService = fileUploadService;
        }

        [HttpPost("{id}/hallphotos")]
        public async Task<IActionResult> AddPhoto(int id, [FromForm]IList<IFormFile> photos)
        {
            if(id==0|| photos == null)
            {
                return NotFound();
            }
            var hallFromRepo = await _repo.GetHall(id);
            if (hallFromRepo == null)
            {
                return NotFound("Hall not found");
            }
            var file = photos;
            var uploadResult = _fileUploadService.UploadFiles(file);
            foreach (var photo in uploadResult)
            {
                hallFromRepo.Photos.Add(photo);
            }
            if (await _repo.SaveAll())
            {
                return Created("Photo Added", uploadResult);
            }
            return BadRequest("Could not add the photo");
        }

        [HttpPost("{id}/itemphotos")]
        public async Task<IActionResult> AddPhotosForItem(int id, [FromForm]IList<IFormFile> photos)
        {
            if (id == 0 || photos == null)
            {
                return NotFound();
            }
            var itemFromRepo = await _repo.GetItem(id);
            if (itemFromRepo == null)
            {
                return NotFound("Item not found");
            }
            var file = photos;
            var uploadResult = _fileUploadService.UploadFiles(file);
            foreach (var photo in uploadResult)
            {
                itemFromRepo.Photos.Add(photo);
            }
            if (await _repo.SaveAll())
            {
                return Created("Photo Added", uploadResult);
            }
            return BadRequest("Could not add the photo");
        }

        [HttpPost("{id}/employeephotos")]
        public async Task<IActionResult> AddPhotosForEmployee(int id, [FromForm]IList<IFormFile> photos)
        {
            if (id == 0 || photos == null)
            {
                return NotFound();
            }
            var empFromRepo = await _repo.GetEmployee(id);
            if (empFromRepo == null)
            {
                return NotFound("Employee not found");
            }
            var file = photos;
            var uploadResult = _fileUploadService.UploadFiles(file);
            empFromRepo.PhotoUrl = uploadResult[0].Filename;
            foreach (var photo in uploadResult)
            {
                empFromRepo.Photos.Add(photo);
            }
            if (await _repo.SaveAll())
            {
                return Created("Photo Added", uploadResult);
            }
            return BadRequest("Could not add the photo");
        }

        [HttpDelete("{id}/hallphotos/")]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var hallFromRepo = await _repo.GetHall(id);
            if (hallFromRepo == null)
            {
                return NotFound("Hall not found");
            }
            _fileUploadService.RemoveExistingImagesFromStorage(hallFromRepo.Photos.ToList());
            hallFromRepo.Photos.Clear();
            if (await _repo.SaveAll())
            {
                return Ok("photos removed");
            }
            return BadRequest("Could not remove the photos");
        }

        [HttpDelete("{id}/itemphotos/")]
        public async Task<IActionResult> DeletePhotosForItem(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var itemFromRepo = await _repo.GetItem(id);
            if (itemFromRepo == null)
            {
                return NotFound("Item not found");
            }
            _fileUploadService.RemoveExistingImagesFromStorage(itemFromRepo.Photos.ToList());
            itemFromRepo.Photos.Clear();
            if (await _repo.SaveAll())
            {
                return Ok("photos removed");
            }
            return BadRequest("Could not remove the photos");
        }

        [HttpDelete("{id}/employeephotos/")]
        public async Task<IActionResult> DeletePhotosForEmployee(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var empFromRepo = await _repo.GetEmployee(id);
            if (empFromRepo == null)
            {
                return NotFound("Employee not found");
            }
            _fileUploadService.RemoveExistingImagesFromStorage(empFromRepo.Photos.ToList());
            empFromRepo.Photos.Clear();
            empFromRepo.PhotoUrl = null;
            if (await _repo.SaveAll())
            {
                return Ok("photos removed");
            }
            return BadRequest("Could not remove the photos");
        }
    }    
}
