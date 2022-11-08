using AutoMapper;
using DeliveryService.DAL.Models;
using DeliveryService.DTO;

namespace DeliveryService.DAL.Profiles
{
    class SupplierProfile : Profile
    {
        public SupplierProfile()

        {
            CreateMap<Supplier, SupplierDTO>().ReverseMap();
        }
    }
}
