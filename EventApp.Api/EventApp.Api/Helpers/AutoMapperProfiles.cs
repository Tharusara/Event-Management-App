using AutoMapper;
using EventApp.Api.DTO;
using EventApp.Api.Models;

namespace EventApp.Api.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserforRegisterDto, User>();
            CreateMap<User, UserForDetailedDto>(); 
            CreateMap<Item, ItemToReturnDto>();
            CreateMap<Payment, PaymentToReturnDto>();
            CreateMap<Supplier, SupplierForReturnDto>();
            CreateMap<Customer, CustomerForReturnDto>();
            CreateMap<Event, EventToReturnDto>();
            CreateMap<Package, PackageToReturnDto>();
            CreateMap<Employee, EmployeeForReturnDto>();
            CreateMap<Hall, HallToReturnDto>();
            CreateMap<Service, ServiceToReturnDto>(); 
            CreateMap<Feature, FeatureForReturnDto>();
            CreateMap<Photo, PhotosDto>();
            CreateMap<EventService, EventServiceDto>().ReverseMap();
            CreateMap<Event, EventToListDto>().ReverseMap();

            CreateMap<User, UserForListDto>().ReverseMap();
            CreateMap<Employee, EmployeeForUpdateDto>().ReverseMap(); 
            CreateMap<Customer, CustomerForUpdateDto>().ReverseMap();
            CreateMap<Supplier, SupplierForUpdateDto>().ReverseMap();
            CreateMap<Item, ItemToUpdateDto>().ReverseMap();
            CreateMap<Event, EventToUpdateDto>().ReverseMap();
            CreateMap<Payment, PaymentToUpdateDto>().ReverseMap();
            CreateMap<Package, PackageForUpdateDto>().ReverseMap();
            CreateMap<Hall, HallForUpdateDto>().ReverseMap();
            CreateMap<Service, ServiceForUpdateDto>().ReverseMap();
        }
    }
}
