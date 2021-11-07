using AutoMapper;
using EventApp.Api.Data;
using EventApp.Api.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventApp.Api.Controllers
{
    [Authorize(Policy = "NormalRoles")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly EventDbContext _context;
        private readonly IMapper _mapper;

        public ReportController(EventDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpGet("hallWiseEvents")]
        public async Task<IActionResult> GetHallWiseEvents()
        {
            //GroupBy(x => x.HallId).https://localhost:44342/api/report/hallWiseEvents
            var EventList = await _context.Events.ToListAsync();
            var eventsToReturn = _mapper.Map<IEnumerable<EventToListDto>>(EventList);
            return Ok(eventsToReturn);
        }
    }
}
