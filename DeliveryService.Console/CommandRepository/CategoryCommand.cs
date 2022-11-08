using AutoMapper;
using DeliveryService.DAL.Concrete;
using DeliveryService.DTO;
using System;

namespace DeliveryService.CommandRepository
{
    internal class CategoryCommand
    {
        static IMapper Mapper = SetupMapper();

        private static IMapper SetupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(CategoryDal).Assembly)
                );
            return config.CreateMapper();
        }

        internal void CreateCategoryCommand(string categoryName, string description)
        {
            var dal = new CategoryDal(Mapper);

            var category = new CategoryDTO
            {
                CategoryName = categoryName,
                Description = description
            };
            category = dal.CreateCategory(category);
            Console.WriteLine($"New category ID : {category.CategoryID}");
        }


        internal void PrintAllCategoriesCommand()
        {
            var dal = new CategoryDal(Mapper);

            var categoriesList = dal.GetAllCategories();

            Console.WriteLine($"\n|{"ID",-5}|{"Categories Name",-15}|\n");
            foreach (var category in categoriesList)
            {
                Console.WriteLine(category.ToString());
            }
        }

        internal void EditCategoryCommand(int сategoryId, string categoryName, string description)
        {
            var dal = new CategoryDal(Mapper);

            var category = new CategoryDTO
            {
                CategoryName = categoryName,
                Description = description
            };
            category = dal.EditCategoryyByID(category, сategoryId);
            Console.WriteLine($"Edited category ID : {(category!=null ? $"{ category.CategoryID}" :"null")}");
        }

        internal void DeleteCategoryCommand(int сategoryId)
        {
            var dal = new CategoryDal(Mapper);
            var category = dal.DeleteCategoryByID(сategoryId);

            Console.WriteLine($"Edited category ID : {(category!=null ? $"{category.CategoryID}" :"null")}");
        }
    }
}
