using AutoMapper;
using DeliveryService.DAL.Concrete;
using DeliveryService.DTO;
using System.Windows;

namespace DeliveryService.WPF.CRUDForModels
{
    /// <summary>
    /// Interaction logic for CategoryCRUD.xaml
    /// </summary>
    public partial class CategoryCRUD : Window
    {
        public CategoryCRUD()
        {
            InitializeComponent();
            GetCategory();

            AddNewCategoryGrid.DataContext = NewCtegory;
        }

        static IMapper Mapper = SetupMapper();
        CategoryDTO NewCtegory = new CategoryDTO();
        CategoryDTO selectedCategory = new CategoryDTO();

        private static IMapper SetupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(CategoryDal).Assembly)
                );
            return config.CreateMapper();
        }

        private void GetCategory()
        {
            var dal = new CategoryDal(Mapper);

            var categoriesList = dal.GetAllCategories();
            CategoryDG.ItemsSource = categoriesList;
        }

        private void AddCategory(object s, RoutedEventArgs e)
        {
            var dal = new CategoryDal(Mapper);

            NewCtegory = dal.CreateCategory(NewCtegory);

            GetCategory();
            NewCtegory = new CategoryDTO();
            AddNewCategoryGrid.DataContext = NewCtegory;
        }

        private void DeleteCategory(object s, RoutedEventArgs e)
        {
            var categoryToBeDeleted = (s as FrameworkElement).DataContext as CategoryDTO;

            var dal = new CategoryDal(Mapper);
            dal.DeleteCategory(categoryToBeDeleted);
            GetCategory();
        }

        private void UpdateCategoryForEdit(object s, RoutedEventArgs e)
        {
            selectedCategory = (s as FrameworkElement).DataContext as CategoryDTO;
            UpdateCategoryGrid.DataContext = selectedCategory;
        }

        private void UpdateCategory(object s, RoutedEventArgs e)
        {
            var dal = new CategoryDal(Mapper);
            dal.EditCategory(selectedCategory);
            GetCategory();
        }
    }
}
