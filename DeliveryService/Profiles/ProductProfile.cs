using AutoMapper;
using DeliveryService.DAL.Models;
using DeliveryService.DTO;

namespace DeliveryService.DAL.Profiles
{
    class ProductProfile : Profile
    {
        public ProductProfile()

        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}