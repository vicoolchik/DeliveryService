using AutoMapper;
using DeliveryService.DAL.Concrete;
using DeliveryService.DTO;
using System;

namespace DeliveryService.CommandRepository
{
    internal class ProductCommand
    {

        static IMapper Mapper = SetupMapper();

        private static IMapper SetupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(ProductDal).Assembly)
                );
            return config.CreateMapper();
        }

        internal void CreateProductCommand(string productName, int supplierID, int categoryID, decimal unitPrice, int unitsInStock, string description)
        {
            var dal = new ProductDal(Mapper);

            var product = new ProductDTO
            {
                ProductName = productName,
                SupplierID = supplierID,
                CategoryID = categoryID,
                UnitPrice = unitPrice,
                UnitsInStock = unitsInStock,
                UnitsOnOnder = 0,
                Discontinued= true,
                Description = description
            };
            product = dal.CreateProduct(product);
            Console.WriteLine($"New product ID : {product.ProductID}");
        }


        internal void PrintAllProductsCommand(int сategoryId)
        {
            var dal = new ProductDal(Mapper);
            
            var productsList = dal.GetAllProductsByCategoryID(сategoryId);

            Console.WriteLine($"|{"ID",-3}|{"Product name",-30}|{"Price",-10}|\n");
            if (productsList == null) Console.WriteLine("There are no products yet\n");
            else
            {
                foreach (var product in productsList)
                {
                    Console.WriteLine(product.ToString());
                }
            }
        }


        internal void DeleteProductCommand(int productId)
        {
            var dal = new ProductDal(Mapper);
            var product = dal.DeleteProductByID(productId);

            Console.WriteLine($"Edited category ID : {(product != null ? $"{product.ProductID}" : "null")}");
        }

        internal void ChangePriceCommand(int productId, decimal unitPrice)
        {
            var dal = new ProductDal(Mapper);
            var product = new ProductDTO
            {
                UnitPrice = unitPrice
            };
            product = dal.EditProductByID(product, productId);
            Console.WriteLine($"Edited product ID : {(product != null ? $"{product.ProductID}" : "null")}");
        }
    }
}
