using AutoMapper;
using EventApp.Api.Data;
using EventApp.Api.DTO;
using EventApp.Api.Helpers;
using EventApp.Api.Models;
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
    public class SharedController : ControllerBase
    {
        private readonly EventDbContext _context;
        private readonly IMapper _mapper;

        public SharedController(EventDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("suppliersWithItems")]
        public async Task<IActionResult> GetSuppliersWithItems([FromQuery]UserParams userParams)
        {
            var userList = _context.Suppliers
                .OrderBy(x => x.Name)
                .Select(supplier => new
                {
                    Id = supplier.Id,
                    Name = supplier.Name,
                    SupplierItems = (from ItemSupplier in supplier.ItemSuppliers
                             join Item in _context.Items
                             on ItemSupplier.ItemId
                             equals Item.Id
                             select Item.Name).ToList()
                }).AsQueryable();
            if (userParams.Name != null)
            {
                userList = userList.Where(u => u.Name.Contains(userParams.Name));
            }
            if (userParams.Id != 0)
            {
                userList = userList.Where(u => u.Id.Equals(userParams.Id));
            }
            return Ok(userList);
        }

        //service
        [HttpGet("suppliersWithServices")]
        public async Task<IActionResult> GetSuppliersWithServices([FromQuery]UserParams userParams)
        {
            var serviceList = _context.Services
                .OrderBy(x => x.Name)
                .Select(service => new
                {
                    Id = service.Id,
                    Name = service.Name,
                    ServiceSuppliers = (from ServiceSupplier in service.ServiceSuppliers
                                     join Supplier in _context.Suppliers
                                     on ServiceSupplier.SupplierId
                                     equals Supplier.Id
                                     select Supplier.Name).ToList()
                }).AsQueryable();
            if (userParams.Name != null)
            {
                serviceList = serviceList.Where(u => u.Name.Contains(userParams.Name));
            }
            if (userParams.Id != 0)
            {
                serviceList = serviceList.Where(u => u.Id.Equals(userParams.Id));
            }
            return Ok(serviceList);
        }

        //item
        [HttpGet("packageWithItems")]
        public async Task<IActionResult> GetPackageWithItems([FromQuery]UserParams userParams)
        {
            var itemList = _context.Items
                .OrderBy(x => x.Name)
                .Select(items => new
                {
                    Id = items.Id,
                    Name = items.Name,
                    PackageItems = (from PackageItem in items.PackageItems
                                        join Package in _context.Packages
                                        on PackageItem.PackageId
                                        equals Package.Id
                                        select Package.Name).ToList()
                }).AsQueryable();
            if (userParams.Name != null)
            {
                itemList = itemList.Where(u => u.Name.Contains(userParams.Name));
            }
            if (userParams.Id != 0)
            {
                itemList = itemList.Where(u => u.Id.Equals(userParams.Id));
            }
            return Ok(itemList);
        }

        //package
        [HttpGet("serviceWithPackages")]
        public async Task<IActionResult> GetServiceWithPackages([FromQuery]UserParams userParams)
        {
            var packageList = _context.Packages
                .OrderBy(x => x.Name)
                .Select(packages => new
                {
                    Id = packages.Id,
                    Name = packages.Name,
                    ServicePackages = (from ServicePackage in packages.PackageServices
                                    join Service in _context.Services
                                    on ServicePackage.ServiceId
                                    equals Service.Id
                                    select Service.Name).ToList()
                }).AsQueryable();
            if (userParams.Name != null)
            {
                packageList = packageList.Where(u => u.Name.Contains(userParams.Name));
            }
            if (userParams.Id != 0)
            {
                packageList = packageList.Where(u => u.Id.Equals(userParams.Id));
            }
            return Ok(packageList);
        }

        [HttpGet("eventServices")]
        public async Task<IActionResult> GetEventServices([FromQuery]UserParams userParams)
        {
            var events = await _context.EventServices.ToListAsync();
            var eventsToReturn = _mapper.Map<IEnumerable<EventServiceDto>>(events);            
            return Ok(eventsToReturn);
        }

        [HttpGet("eventsWithServices")]
        public async Task<IActionResult> GetEventsWithServices([FromQuery]UserParams userParams)
        {
            var eventList = _context.Events
                .OrderBy(x => x.Start)
                .Select(events => new
                {
                    Id = events.Id,
                    Title = events.Title,
                    Start = events.Start,
                    End = events.End,
                    Price =events.Fee + events.HallFee,
                    EventServices = (from EventService in events.EventServices
                                       join Service in _context.Services
                                       on EventService.ServiceId
                                       equals Service.Id
                                       select Service.Name).ToList()
                }).AsQueryable();
            if (userParams.Name != null)
            {
                eventList = eventList.Where(u => u.Title.Contains(userParams.Name));
            }
            if (userParams.Id != 0)
            {
                eventList = eventList.Where(u => u.Id.Equals(userParams.Id));
            }
            if (userParams.StartDate != new DateTime() || userParams.EndDate != new DateTime())
            {
                eventList = eventList
                    .Where(u => u.Start >= userParams.StartDate && u.End <= userParams.EndDate);
            }
            return Ok(eventList);
        }

        [HttpGet("eventsWithItems")]
        public async Task<IActionResult> GetEventsWithItems([FromQuery]UserParams userParams)
        {
            var eventList = _context.Events
                .OrderBy(x => x.Start)
                .Select(events => new
                {
                    Id = events.Id,
                    Title = events.Title,
                    Start = events.Start,
                    GuestCount = events.GuestCount,
                    Price = events.Fee + events.HallFee,
                    EventItems = (from EventItem in events.EventItems
                                     join Item in _context.Items
                                     on EventItem.ItemId
                                     equals Item.Id
                                     select Item.Name).ToList()
                }).AsQueryable();
            if (userParams.Name != null)
            {
                eventList = eventList.Where(u => u.Title.Contains(userParams.Name));
            }
            if (userParams.Id != 0)
            {
                eventList = eventList.Where(u => u.Id.Equals(userParams.Id));
            }
            if (userParams.StartDate != new DateTime() || userParams.EndDate != new DateTime())
            {
                eventList = eventList
                    .Where(u => u.Start >= userParams.StartDate && u.Start <= userParams.EndDate);
            }
            return Ok(eventList);
        }

        //Employee
        [HttpGet("eventsWithEmployees")]
        public async Task<IActionResult> GetEventsWithEmployees([FromQuery]UserParams userParams)
        {
            var employeeList = _context.Employees
                .OrderBy(x => x.CallingName)
                .Select(employees => new
                {
                    Id = employees.Id,
                    FullName = employees.FullName,
                    Designation = employees.Designation,
                    Dorecruite = employees.Dorecruite,
                    EndContract = employees.Dorecruite.AddYears(1),
                    EventEmployees = (from EventEmployee in employees.EventEmployees
                                  join Event in _context.Events
                                  on EventEmployee.EventId
                                  equals Event.Id
                                  select Event.Title).ToList()
                }).AsQueryable();
            if (userParams.Name != null)
            {
                employeeList = employeeList.Where(u => u.FullName.Contains(userParams.Name));
            }
            if (userParams.Id != 0)
            {
                employeeList = employeeList.Where(u => u.Id.Equals(userParams.Id));
            }
            if (userParams.StartDate != new DateTime() || userParams.EndDate != new DateTime())
            {
                employeeList = employeeList
                    .Where(u => u.Dorecruite >= userParams.StartDate && u.Dorecruite <= userParams.EndDate);
            }
            return Ok(employeeList);
        }

        //package
        [HttpGet("hallWithFeatures")]
        public async Task<IActionResult> GetHallWithFeatures([FromQuery]UserParams userParams)
        {
            var hallList = _context.Halls
                .OrderBy(x => x.Name)
                .Select(halls => new
                {
                    Id = halls.Id,
                    Name = halls.Name,
                    Description = halls.Description,
                    Hourfee = halls.Hourfee,
                    HallFeatures = (from HallFeature in halls.HallFeatures
                                       join Feature in _context.Features
                                       on HallFeature.FeatureId
                                       equals Feature.Id
                                       select Feature.Name).ToList()
                }).AsQueryable();
            if (userParams.Name != null)
            {
                hallList = hallList.Where(u => u.Name.Contains(userParams.Name));
            }
            if (userParams.Id != 0)
            {
                hallList = hallList.Where(u => u.Id.Equals(userParams.Id));
            }
            return Ok(hallList);
        }
    }
}
