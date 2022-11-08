using AutoMapper;
using DeliveryService.DAL.Concrete;
using DeliveryService.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DeliveryService.WPF.CRUDForModels
{
    /// <summary>
    /// Interaction logic for ProductCRUD.xaml
    /// </summary>
    public partial class ProductCRUD : Window
    {
        public ProductCRUD()
        {
            InitializeComponent();
            GetProduct();

            AddNewProductGrid.DataContext = NewProduct;
        }
        static IMapper Mapper = SetupMapper();
        ProductDTO NewProduct = new ProductDTO();
        ProductDTO selectedProduct = new ProductDTO();

        private static IMapper SetupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(ProductDal).Assembly)
                );
            return config.CreateMapper();
        }


        private void GetProduct()
        {
            var dal = new ProductDal(Mapper);

            var productsList = dal.GetAllProducts();
            ProductDG.ItemsSource = productsList;
        }

        private void AddProduct(object s, RoutedEventArgs e)
        {
            var dal = new ProductDal(Mapper);
            NewProduct.UnitsInStock = 1;
            NewProduct = dal.CreateProduct(NewProduct);

            GetProduct();
            NewProduct = new ProductDTO();
            AddNewProductGrid.DataContext = NewProduct;
        }

        private void DeleteProduct(object s, RoutedEventArgs e)
        {
            var productToBeDeleted = (s as FrameworkElement).DataContext as ProductDTO;

            var dal = new ProductDal(Mapper);
            dal.DeleteProduct(productToBeDeleted);
            GetProduct();
        }

        private void UpdateProductForEdit(object s, RoutedEventArgs e)
        {
            selectedProduct = (s as FrameworkElement).DataContext as ProductDTO;
            UpdateProductGrid.DataContext = selectedProduct;
        }

        private void UpdateProduct(object s, RoutedEventArgs e)
        {
            var dal = new ProductDal(Mapper);
            dal.EditProduct(selectedProduct);
            GetProduct();
        }
    }
}
