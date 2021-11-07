using EventApp.Api.Helpers;
using EventApp.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EventApp.Api.Data
{
    public class EventRepository : IEventRepository
    {
        private readonly EventDbContext _context;
        public EventRepository(EventDbContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<User> GetUser(int Id)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == Id);
            return user;
        }

        public async Task<Photo> GetPhoto(int Id)
        {
            var photo = await _context.Photos
                .FirstOrDefaultAsync(u => u.Id == Id);
            return photo;
        }

        public async Task<IEnumerable<Photo>> GetPhotos()
        {
            var photos = await _context.Photos.ToListAsync();
            return photos;
        }

        public async Task<Employee> GetEmployee(int Id)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(u => u.Id == Id);
            return employee;
        }

        public async Task<PagedList<Employee>> GetEmployees(UserParams userParams)
        {
            var employees = _context.Employees.AsQueryable();
            if (userParams.Mobile != null)
            {
                employees = employees.Where(u => u.Mobile.Contains(userParams.Mobile));
            }
            if (userParams.Nic != null)
            {
                employees = employees.Where(u => u.Nic.Contains(userParams.Nic));
            }
            if (userParams.Name != null)
            {
                employees = employees.Where(u => u.FullName.Contains(userParams.Name));
            }
            if (userParams.Designation != 0)
            {
                employees = employees.Where(u => (int)u.Designation==userParams.Designation);
            }
            if (userParams.MinAge != new DateTime() || userParams.MaxAge != new DateTime())
            {
                employees = employees
                    .Where(u => u.Dorecruite >= userParams.MinAge && u.Dorecruite <= userParams.MaxAge);
            }
            return await PagedList<Employee>.CreateAsync(employees, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<PagedList<User>> GetUsers(UserParams userParams)
        {
            var users = _context.Users.AsQueryable();
            if (userParams.Gender != null)
            {
                users = users.Where(u => u.Gender == userParams.Gender);
            }
            if (userParams.Name != null)
            {
                users = users.Where(u => u.UserName.Contains(userParams.Name));
            }            
            if (userParams.Id != 0)
            {
                users = users.Where(u => u.Id.Equals(userParams.Id));
            }
            return await PagedList<User>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);

        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<PagedList<Customer>> GetCustomers(UserParams userParams)
        {
            var customers = _context.Customers.AsQueryable();
            if (userParams.Mobile != null)
            {
                customers = customers.Where(u => u.Contact1.Contains(userParams.Mobile));
            }
            if (userParams.Nic != null)
            {
                customers = customers.Where(u => u.Nic.Contains(userParams.Nic));
            }
            if (userParams.Name != null)
            {
                customers = customers.Where(u => u.Name.Contains(userParams.Name));
            }
            if (userParams.Code != null)
            {
                customers = customers.Where(u => u.Code.Contains(userParams.Code));
            }
            return await PagedList<Customer>.CreateAsync(customers, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<Customer> GetCustomer(int Id)
        {
            var customer = await _context.Customers
                .FirstOrDefaultAsync(u => u.Id == Id);
            return customer;
        }

        public async Task<PagedList<Supplier>> GetSuppliers(UserParams userParams)
        {
            var suppliers = _context.Suppliers.AsQueryable();
            if (userParams.Mobile != null)
            {
                suppliers = suppliers.Where(u => u.Contact1.Contains(userParams.Mobile));
            }
            if (userParams.Nic != null)
            {
                suppliers = suppliers.Where(u => u.Nic.Contains(userParams.Nic));
            }
            if (userParams.Name != null)
            {
                suppliers = suppliers.Where(u => u.Name.Contains(userParams.Name));
            }
            if (userParams.Code != null)
            {
                suppliers = suppliers.Where(u => u.Code.Contains(userParams.Code));
            }
            if (userParams.SupplierStatus != 0)
            {
                suppliers = suppliers.Where(u => (int)u.SupplierStatus == userParams.SupplierStatus);
            }
            if (userParams.SupplierType != 0)
            {
                suppliers = suppliers.Where(u => (int)u.SupplierType == userParams.SupplierType);
            }
            return await PagedList<Supplier>.CreateAsync(suppliers, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<Supplier> GetSupplier(int Id)
        {
            var supplier = await _context.Suppliers
                .FirstOrDefaultAsync(u => u.Id == Id);
            return supplier;
        }

        public async Task<PagedList<Item>> GetItems(UserParams userParams)
        {
            var items = _context.Items.AsQueryable();

            if (userParams.Name != null)
            {
                items = items.Where(u => u.Name.Contains(userParams.Name));
            }
            if (userParams.Code != null)
            {
                items = items.Where(u => u.Code.Contains(userParams.Code));
            }
            if (userParams.ItemStatus != 0)
            {
                items = items.Where(u => (int)u.ItemStatus == userParams.ItemStatus);
            }
            if (userParams.Price != 0)
            {
                items = items.Where(u => (int)u.UnitPrice == userParams.Price);
            }
            return await PagedList<Item>.CreateAsync(items, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<Item> GetItem(int Id)
        {
            var item = await _context.Items
                .FirstOrDefaultAsync(u => u.Id == Id);
            return item;
        }
        public async Task<ItemSupplier> GetItemSupplier(int Id, int itemId)
        {
            return await _context.ItemSuppliers.FirstOrDefaultAsync(u =>
                u.SupplierId == Id && u.ItemId == itemId);
        }

        public async Task<PagedList<Payment>> GetPayments(UserParams userParams)
        {
            var payments = _context.Payments.AsQueryable();

            if (userParams.ChequeNo != null)
            {
                payments = payments.Where(u => u.ChequeNo.Contains(userParams.ChequeNo));
            }
            if (userParams.Code != null)
            {
                payments = payments.Where(u => u.Code.Contains(userParams.Code));
            }
            if (userParams.PaymentStatus != 0)
            {
                payments = payments.Where(u => (int)u.PaymentStatus == userParams.PaymentStatus);
            }
            if (userParams.PaymentType != 0)
            {
                payments = payments.Where(u => (int)u.PaymentType == userParams.PaymentType);
            }
            return await PagedList<Payment>.CreateAsync(payments, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<Payment> GetPayment(int Id)
        {
            var payment = await _context.Payments
                .FirstOrDefaultAsync(u => u.Id == Id);
            return payment;
        }

        public async Task<PagedList<Service>> GetServices(UserParams userParams)
        {
            var services = _context.Services.AsQueryable();

            if (userParams.Name != null)
            {
                services = services.Where(u => u.Name.Contains(userParams.Name));
            }
            if (userParams.Code != null)
            {
                services = services.Where(u => u.Code.Contains(userParams.Code));
            }
            if (userParams.ServiceStatus != 0)
            {
                services = services.Where(u => (int)u.ServiceStatus == userParams.ServiceStatus);
            }
            //if (userParams.StartDate != null || userParams.EndDate != null)
            //{
            //    var minDob = DateTime.Today.AddYears(userParams.EndDate);
            //    var maxDob = DateTime.Today.AddYears(userParams.StartDate);
            //    services = services.Where(u => u.Tocreation >= minDob && u.Tocreation <= maxDob);
            //}
            if (userParams.StartDate != new DateTime() || userParams.EndDate != new DateTime())
            {
                services = services
                    .Where(u => u.Tocreation >= userParams.StartDate && u.Tocreation <= userParams.EndDate);
            }
            return await PagedList<Service>.CreateAsync(services, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<Service> GetService(int Id)
        {
            var service = await _context.Services
                .FirstOrDefaultAsync(u => u.Id == Id);
            return service;
        }

        public async Task<PagedList<Hall>> GetHalls(UserParams userParams)
        {
            var halls = _context.Halls.AsQueryable();

            if (userParams.Name != null)
            {
                halls = halls.Where(u => u.Name.Contains(userParams.Name));
            }
            if (userParams.Code != null)
            {
                halls = halls.Where(u => u.Code.Contains(userParams.Code));
            }
            if (userParams.HallStatus != 0)
            {
                halls = halls.Where(u => (int)u.HallStatus == userParams.HallStatus);
            }
            if (userParams.HallType != 0)
            {
                halls = halls.Where(u => (int)u.HallType == userParams.HallType);
            }
            return await PagedList<Hall>.CreateAsync(halls, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<Hall> GetHall(int Id)
        {
            var hall = await _context.Halls
                .FirstOrDefaultAsync(u => u.Id == Id);
            return hall;
        }

        public async Task<PagedList<Package>> GetPackages(UserParams userParams)
        {
            var packages = _context.Packages.AsQueryable();

            if (userParams.Name != null)
            {
                packages = packages.Where(u => u.Name.Contains(userParams.Name));
            }
            if (userParams.Code != null)
            {
                packages = packages.Where(u => u.Code.Contains(userParams.Code));
            }
            if (userParams.PackageStatus != 0)
            {
                packages = packages.Where(u => (int)u.PackageStatus == userParams.PackageStatus);
            }
            if (userParams.Price != 0)
            {
                packages = packages.Where(u => u.Price == userParams.Price);
            }
            return await PagedList<Package>.CreateAsync(packages, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<Package> GetPackage(int Id)
        {
            var package = await _context.Packages
                .FirstOrDefaultAsync(u => u.Id == Id);
            return package;
        }

        public async Task<PagedList<Event>> GetEvents(UserParams userParams)
        {
            var events = _context.Events.OrderByDescending(x=>x.Start).AsQueryable();

            if (userParams.Name != null)
            {
                events = events.Where(u => u.Title.Contains(userParams.Name));
            }
            if (userParams.GuestCount != 0)
            {
                events = events.Where(u => u.GuestCount == userParams.GuestCount);
            }
            if (userParams.EventStatus != 0)
            {
                events = events.Where(u => (int)u.EventStatus == userParams.EventStatus);
            }
            if (userParams.EventType != 0)
            {
                events = events.Where(u => (int)u.EventType == userParams.EventType);
            }
            if (userParams.MinAge != new DateTime() || userParams.MaxAge != new DateTime())
            {
                events = events
                    .Where(u => u.Start >= userParams.MinAge && u.Start <= userParams.MaxAge);
            }
            return await PagedList<Event>.CreateAsync(events, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<Event> GetEvent(int Id)
        {
            var function = await _context.Events
                .FirstOrDefaultAsync(u => u.Id == Id);
            return function;
        }

        public async Task<Event> GetEventByDate(DateTime startdate, DateTime enddate )
        {
            var function =await _context.Events.FirstOrDefaultAsync(x => x.Start == startdate && x.End == enddate);
            //function.Where(x => x.Start == startdate && x.End == enddate);
            return function;
        }
        //Task<IQueryable<EventService>> IEventRepository.GetEventByDate(DateTime startdate, DateTime enddate)
        //{
        //    var function = _context.Events.AsQueryable();
        //    function.Where(x => x.Start == startdate && x.End == enddate);
        //    return function;
        //}

        public async Task<PackageService> GetPackageService(int Id, int serviceId)
        {
            return await _context.PackageServices.FirstOrDefaultAsync(u =>
                u.PackageId == Id && u.ServiceId == serviceId);
        }

        public async Task<ServiceSupplier> GetServiceSupplier(int Id, int supplierId)
        {
            return await _context.ServiceSuppliers.FirstOrDefaultAsync(u =>
                u.ServiceId == Id && u.SupplierId == supplierId);
        }

        public async Task<PackageItem> GetPackageItem(int Id, int itemId)
        {
            return await _context.PackageItems.FirstOrDefaultAsync(u =>
                u.PackageId == Id && u.ItemId == itemId);
        }

        public async Task<EventService> GetEventService(int Id, int serviceId)
        {
            return await _context.EventServices.FirstOrDefaultAsync(u =>
                u.EventId == Id && u.ServiceId == serviceId);
        }

        public async Task<EventItem> GetEventItem(int Id, int itemId)
        {
            return await _context.EventItems.FirstOrDefaultAsync(u =>
                u.EventId == Id && u.ItemId == itemId);
        }

        public async Task<EventEmployee> GetEventEmployee(int Id, int eventId)
        {
            return await _context.EventEmployees.FirstOrDefaultAsync(u =>
                u.EmployeeId == Id && u.EventId == eventId);
        }

        public async Task<HallFeature> GetHallFeature(int Id, int featureId)
        {
            return await _context.HallFeatures.FirstOrDefaultAsync(u =>
                u.HallId == Id && u.FeatureId == featureId);
        }

        public async Task<PagedList<Feature>> GetFeatures(UserParams userParams)
        {
            var features = _context.Features.AsQueryable();

            if (userParams.Name != null)
            {
                features = features.Where(u => u.Name.Contains(userParams.Name));
            }
            if (userParams.Id != 0)
            {
                features = features.Where(u => u.Id == userParams.Id);
            }
            return await PagedList<Feature>.CreateAsync(features, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<Feature> GetFeature(int Id)
        {
            var feature = await _context.Features
                .FirstOrDefaultAsync(u => u.Id == Id);
            return feature;
        }

    }
}
