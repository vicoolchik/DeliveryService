using DeliveryService.WPF.CRUDForModels;
using System.Windows;

namespace DeliveryService.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenCategoryWindow(object sender, RoutedEventArgs e)
        {
            CategoryCRUD category = new CategoryCRUD();
            category.ShowDialog();
        }

        private void OpenProductWindow(object sender, RoutedEventArgs e)
        {
            ProductCRUD product = new ProductCRUD();
            product.ShowDialog();
        }
    }
}
