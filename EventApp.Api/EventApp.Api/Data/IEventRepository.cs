using EventApp.Api.Helpers;
using EventApp.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventApp.Api.Data
{
    public interface IEventRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();

        Task<PagedList<Event>> GetEvents(UserParams userParams);
        Task<Event> GetEvent(int Id);
        Task<EventService> GetEventService(int Id, int serviceId);
        Task<Event> GetEventByDate(DateTime startdate, DateTime enddate);
        Task<EventItem> GetEventItem(int Id, int itemId); 

         Task<PagedList<Hall>> GetHalls(UserParams userParams);
        Task<Hall> GetHall(int Id);
        Task<HallFeature> GetHallFeature(int Id, int featureId);

        Task<PagedList<Feature>> GetFeatures(UserParams userParams);
        Task<Feature> GetFeature(int Id);

        Task<PagedList<Package>> GetPackages(UserParams userParams);
        Task<Package> GetPackage(int Id);
        Task<PackageService> GetPackageService(int Id, int serviceId);

        Task<PagedList<Service>> GetServices(UserParams userParams);
        Task<Service> GetService(int Id);
        Task<ServiceSupplier> GetServiceSupplier(int Id, int supplierId);

        Task<PagedList<Item>> GetItems(UserParams userParams);
        Task<Item> GetItem(int Id);
        Task<ItemSupplier> GetItemSupplier(int Id, int itemId);
        Task<PackageItem> GetPackageItem(int Id, int itemId);

        Task<PagedList<Payment>> GetPayments(UserParams userParams);
        Task<Payment> GetPayment(int Id);

        Task<PagedList<Supplier>> GetSuppliers(UserParams userParams);
        Task<Supplier> GetSupplier(int Id);

        Task<PagedList<Customer>> GetCustomers(UserParams userParams);
        Task<Customer> GetCustomer(int Id);

        Task<PagedList<Employee>> GetEmployees(UserParams userParams);
        Task<Employee> GetEmployee(int Id);
        Task<EventEmployee> GetEventEmployee(int Id, int eventId);

        Task<PagedList<User>> GetUsers(UserParams userParams);
        Task<User> GetUser(int Id);

        Task<IEnumerable<Photo>> GetPhotos();
        Task<Photo> GetPhoto(int Id);
    }
}
