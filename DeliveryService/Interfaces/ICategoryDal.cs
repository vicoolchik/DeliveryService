using DeliveryService.DTO;
using System.Collections.Generic;

namespace DeliveryService.DAL.Interfaces
{
    public interface ICategoryDal
    {
        List<CategoryDTO> GetAllCategories();
        CategoryDTO CreateCategory(CategoryDTO category);
        CategoryDTO DeleteCategoryByID(int id);
        CategoryDTO EditCategoryyByID(CategoryDTO category, int id);
    }
}
