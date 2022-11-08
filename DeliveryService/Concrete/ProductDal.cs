using AutoMapper;
using DeliveryService.DAL.Interfaces;
using DeliveryService.DAL.Models;
using DeliveryService.DTO;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryService.DAL.Concrete
{
    public class ProductDal : IProductDal
    {
        private readonly IMapper _mapper;
        public ProductDal(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ProductDTO CreateProduct(ProductDTO product)
        {
            using (var entites = new ProductcompanyContext())
            {
                var productInDB = _mapper.Map<Product>(product);
                productInDB.RowInsertTime = System.DateTime.Now;
                productInDB.RowUpdateTime = System.DateTime.Now;
                entites.Products.Add(productInDB);
                entites.SaveChanges();
                return _mapper.Map<ProductDTO>(productInDB);
            }
        }

        public List<ProductDTO> GetAllProductsByCategoryID(int categoryID)
        {
            using (var entities = new ProductcompanyContext())
            {
                var productInDB = entities.Products.Where(x => x.CategoryId == categoryID).ToList();
                if (productInDB.Count == 0 || productInDB == null) return null;
                return _mapper.Map<List<ProductDTO>>(productInDB);
            }
        }

        public List<ProductDTO> GetAllProducts()
        {
            using (var entities = new ProductcompanyContext())
            {
                var productInDB = entities.Products.ToList();
                return _mapper.Map<List<ProductDTO>>(productInDB);
            }
        }

        public ProductDTO EditProductByID(ProductDTO product, int id)
        {
            using (var entites = new ProductcompanyContext())
            {
                var productInDB = _mapper.Map<Product>(product);
                productInDB = entites.Products.SingleOrDefault(x => x.ProductId == id);
                if (productInDB != null)
                {
                    productInDB.RowUpdateTime = System.DateTime.Now;
                    productInDB.UnitPrice = product.UnitPrice;
                    entites.SaveChanges();
                    return _mapper.Map<ProductDTO>(productInDB);
                }
                return null;
            }
        }

        public ProductDTO EditProduct(ProductDTO product)
        {
            using (var entites = new ProductcompanyContext())
            {
                var productInDB = _mapper.Map<Product>(product);
                productInDB = entites.Products.SingleOrDefault(x => x.ProductId == product.ProductID);
                if (productInDB != null)
                {
                    productInDB.RowUpdateTime = System.DateTime.Now;
                    productInDB.UnitPrice = product.UnitPrice;
                    productInDB.Description = product.Description;
                    productInDB.ProductName = product.ProductName;
                    entites.SaveChanges();
                    return _mapper.Map<ProductDTO>(productInDB);
                }
                return null;
            }
        }

        public ProductDTO DeleteProductByID(int id)
        {
            using (var entites = new ProductcompanyContext())
            {
                var productsInDB = entites.Products.SingleOrDefault(x => x.ProductId == id);
                if (productsInDB != null)
                {
                    entites.Products.Remove(productsInDB);
                    entites.SaveChanges();
                    return _mapper.Map<ProductDTO>(productsInDB);
                }
                return null;
            }
        }

        public ProductDTO DeleteProduct(ProductDTO product)
        {
            using (var entites = new ProductcompanyContext())
            {
                var productInDB = _mapper.Map<Product>(product);
                var productsInDB = entites.Products.SingleOrDefault(x => x.ProductId == product.ProductID);
                if (productsInDB != null)
                {
                    entites.Products.Remove(productsInDB);
                    entites.SaveChanges();
                    return _mapper.Map<ProductDTO>(productsInDB);
                }
                return null;
            }
        }

    }
}

