using System.Collections.Generic;
using DeliveryService.DTO;

namespace DeliveryService.DAL.Interfaces
{
    public interface IProductDal
    {
        List<ProductDTO> GetAllProductsByCategoryID(int categoryID);
        ProductDTO CreateProduct(ProductDTO product);
        ProductDTO EditProductByID(ProductDTO product, int id);
        ProductDTO DeleteProductByID(int id);
    }
}
