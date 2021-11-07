using AutoMapper;
using EventApp.Api.Data;
using EventApp.Api.DTO;
using EventApp.Api.Helpers;
using EventApp.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EventApp.Api.Controllers
{
    [Authorize(Policy = "NormalRoles")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _repo;
        private readonly IMapper _mapper;

        public EventController(IEventRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]UserParams userParams)
        {
            var events = await _repo.GetEvents(userParams);
            var eventsToReturn = _mapper.Map<IEnumerable<EventToReturnDto>>(events);
            Response.AddPagination(events.CurrentPage, events.PageSize, events.TotalCount, events.TotalPages);
            return Ok(eventsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var function = await _repo.GetEvent(Id);
            var eventToReturn = _mapper.Map<EventToReturnDto>(function);
            return Ok(eventToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Event eventForCreation)
        {
            if (eventForCreation == null)
            {
                return BadRequest("Event data is null");
            }
            eventForCreation.Start = eventForCreation.Start.AddDays(1);
            eventForCreation.End = eventForCreation.End.AddDays(1);
            //var currentEvent = _repo.GetEventByDate(eventForCreation.Start, eventForCreation.End);
            //if (currentEvent != null )
            //{
            //    return NotFound("Event Date Is not available");
            //}
            eventForCreation.CreatorId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            _repo.Add(eventForCreation);
            if (await _repo.SaveAll())
            {
                return Created("Event Successfully Added", eventForCreation);
            }
            return BadRequest("Adding the Event Failed on save");
        }

        [HttpPost("{id}/addServices")]
        public async Task<IActionResult> AddServices(int id, ServiceEditDto services)
        {
            if (await _repo.GetEvent(id) == null)
                return NotFound();
            var selectedItems = services.ServiceId;
            if (services.ServiceId == null || services.ServiceId.Length == 0)
                return NotFound();
            for (int i = 0; i < selectedItems.Length; i++)
            {
                var item = await _repo.GetEventService(id, selectedItems[i]);
                if (item != null)
                    continue;
                item = new EventService
                {
                    EventId = id,
                    ServiceId = selectedItems[i]
                };
                _repo.Add(item);
            }
            if (await _repo.SaveAll())
                return Ok();
            return BadRequest(new { message = "Event already has this service" });
        }

        [HttpPost("{id}/addItems")]
        public async Task<IActionResult> AddItem(int id, ItemEditDto items)
        {
            if (await _repo.GetEvent(id) == null)
                return NotFound();
            var selectedItems = items.ItemId;
            if (items.ItemId == null || items.ItemId.Length == 0)
                return NotFound();
            for (int i = 0; i < selectedItems.Length; i++)
            {
                var item = await _repo.GetEventItem(id, selectedItems[i]);
                if (item != null)
                    continue;
                item = new EventItem
                {
                    EventId = id,
                    ItemId = selectedItems[i]
                };
                _repo.Add(item);
            }
            if (await _repo.SaveAll())
                return Ok();
            return BadRequest(new { message = "Event already supply this items" });
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
                var itemToDelete = await _repo.GetEventItem(id, selectedItems[i]);
                if (itemToDelete != null)
                {
                    _repo.Delete(itemToDelete);
                }
            }
            if (await _repo.SaveAll())
                return Ok(new { message = "items are removed from Event successfully." });
            return NotFound();
        }

        [HttpPut("{id}/removeServices")]
        public async Task<IActionResult> RemoveServices(int id, ServiceEditDto services)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var selectedItems = services.ServiceId;
            for (int i = 0; i < selectedItems.Length; i++)
            {
                var itemToDelete = await _repo.GetEventService(id, selectedItems[i]);
                if (itemToDelete != null)
                {
                    _repo.Delete(itemToDelete);
                }
            }
            if (await _repo.SaveAll())
                return Ok(new { message = "services are removed from Event successfully." });
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EventToUpdateDto eventForUpdate)
        {
            if (eventForUpdate == null || id == 0)
            {
                return BadRequest();
            }
            eventForUpdate.Id = id;
            var eventFromRepo = await _repo.GetEvent(id);
            if (eventFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(eventForUpdate, eventFromRepo);
            if (await _repo.SaveAll())
                return NoContent();

            return BadRequest($"Updating Event{id} failed on save");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var eventToDelete = await _repo.GetEvent(id);
            if (eventToDelete == null)
            {
                return NotFound();
            }
            _repo.Delete(eventToDelete);
            await _repo.SaveAll();
            return Ok(new { message = "Event is removed successfully." });
        }
    }
}
