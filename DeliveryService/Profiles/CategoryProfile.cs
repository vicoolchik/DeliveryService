using AutoMapper;
using DeliveryService.DAL.Models;
using DeliveryService.DTO;

namespace DeliveryService.DAL.Profiles
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
