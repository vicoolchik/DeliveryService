using DeliveryService;
using DeliveryService.CommandRepository;
using System;

namespace DeliveryService
{
    class ProductManagerMenu
    {
		
		private CategoryCommand categoryCommand = new CategoryCommand();
		private ProductCommand productCommand = new ProductCommand();
		private SupplierCommand supplierCommand = new SupplierCommand();

		public void runMenu()
		{
			showMenuOption();
		}


		private void showMenuOption()
		{
			char userInput = ' ';
			while (userInput != '0')
			{
				Console.Clear();
				Console.WriteLine("Welcome to the Product Company\n");
				Console.WriteLine("Please select an option:\n");
				Console.WriteLine("1) Work with categories");
				Console.WriteLine("2) Work with products");
				Console.WriteLine("0) Exit");
				Console.Write("Your choice : ");

				userInput = Console.ReadKey().KeyChar;
				selectShowMenuOption(userInput);
			}
		}

		private void selectShowMenuOption(char userInput)
		{
			switch (userInput)
			{
				case '1':
					showCategoriesMenu();
					break;
				case '2':
					showProductsMenu();
					break;
				case '0':
					break;
				default:
					printDefaultSwitchStringMenu();
					break;
			}
		}

        private void showProductsMenu()
        {
			char userInput = ' ';
			int? сategoryId = null;

			while (!(сategoryId is int))
			{
				Console.Clear();
				Console.WriteLine("Select the product category you want to work with.");
				сategoryId = TrySelectCategoryByIDMenu();
			}
			while (userInput != '0')
			{
				Console.Clear();
				productCommand.PrintAllProductsCommand((int)сategoryId);
				Console.WriteLine();
				Console.WriteLine("1) Add a product");
				Console.WriteLine("2) Change the price");
				Console.WriteLine("3) Delete product");
				Console.WriteLine("0) Exit");
				Console.Write("Your choice : ");

				userInput = Console.ReadKey().KeyChar;
				selectProductsMenuOption(userInput, (int) сategoryId );
			}
		}

        private void selectProductsMenuOption(char userInput, int сategoryId)
        {
			switch (userInput)
			{
				case '1':
					AddProductMenu(сategoryId);
					break;
				case '2':
					ChangeProductPriceMenu(сategoryId);
					break;
				case '3':
					DeleteProductMenu(сategoryId);
					break;
				case '0':
					break;
				default:
					printDefaultSwitchStringMenu();
					break;
			}
		}

        private void DeleteProductMenu(int сategoryId)
        {
			int? productId = null;
			while (!(productId is int)) productId = TrySelectProductByIDMenu(сategoryId);

			productCommand.DeleteProductCommand((int)productId);
		}

        private void ChangeProductPriceMenu(int сategoryId)
        {
			int? productId = null;
			while (!(productId is int)) productId = TrySelectProductByIDMenu(сategoryId);

			Console.Clear();
			Console.WriteLine("Enter a new product price : ");
			decimal productPrice;
			decimal.TryParse(Console.ReadLine(), out productPrice);
			productCommand.ChangePriceCommand((int)productId, productPrice);
		}

        private void AddProductMenu(int сategoryId)
        {
			Console.Clear();
			Console.WriteLine("Enter the name of the product : ");
			string productName = Console.ReadLine();
			Console.WriteLine("Enter the price of the product : ");
			decimal productPrice;
			decimal.TryParse(Console.ReadLine(), out productPrice);
			Console.WriteLine("Enter the quantity of the product  in stock  : ");
			int unitsInStock;
			int.TryParse(Console.ReadLine(), out unitsInStock);
			Console.WriteLine("Write a short description of the product : ");
			string description = Console.ReadLine();

			int? supplierId = null;
			while (!(supplierId is int)) supplierId = TrySelectSupplierIdByIDMenu();

			productCommand.CreateProductCommand(productName, (int)supplierId, сategoryId, productPrice, unitsInStock, description);

		}

        private int? TrySelectSupplierIdByIDMenu()
        {
			Console.Clear();
			supplierCommand.PrintAllSuppliersCommand();

			int supplierId;

			Console.Write("\nSelect the supplier Id : ");

			bool success = int.TryParse(Console.ReadLine(), out supplierId);
			return success ? (int?)supplierId : (int?)null;
		}

        private void showCategoriesMenu()
        {
			char userInput = ' ';
			while (userInput != '0')
			{
				Console.Clear();
				categoryCommand.PrintAllCategoriesCommand();
				Console.WriteLine();
				Console.WriteLine("1) Create category");
				Console.WriteLine("2) Edit category");
				Console.WriteLine("3) Delete category");
				Console.WriteLine("0) Exit");
				Console.Write("Your choice : ");

				userInput = Console.ReadKey().KeyChar;
				selectCategoriesMenuOption(userInput);
			}
		}

        private void selectCategoriesMenuOption(char userInput)
        {
			switch (userInput)
			{
				case '1':
					CreateCategoryMenu();					
					break;
				case '2':
					EditCategoryMenu();
					break;
				case '3':
					DeleteCategoryMenu();					
					break;
				case '0':
					break;
				default:
					printDefaultSwitchStringMenu();
					break;
			}
		}

        private void DeleteCategoryMenu()
        {
			Console.Clear();
			int? сategoryId = null;
			while (!(сategoryId is int)) сategoryId = TrySelectCategoryByIDMenu();

			categoryCommand.DeleteCategoryCommand((int)сategoryId);
		}

		private void CreateCategoryMenu()
        {
			Console.Clear();
			Console.WriteLine("Enter the name of the category : ");
			string categoryName = Console.ReadLine();
			Console.WriteLine("Write a short description of the category : ");
			string description = Console.ReadLine();

			categoryCommand.CreateCategoryCommand(categoryName, description);
		}

		private void EditCategoryMenu()
        {
			int? сategoryId=null;
			while(!(сategoryId is int)) сategoryId = TrySelectCategoryByIDMenu();

			Console.Clear();
			Console.WriteLine("Enter a new category name : ");
			string categoryName = Console.ReadLine();
			Console.WriteLine("Write a short description of the category : ");
			string description = Console.ReadLine();

			categoryCommand.EditCategoryCommand((int)сategoryId, categoryName, description);
		}

		private int? TrySelectCategoryByIDMenu()
        {
			Console.Clear();
			categoryCommand.PrintAllCategoriesCommand();

			int categoryId;

			Console.Write("\nSelect the category id : ");

			bool success = int.TryParse(Console.ReadLine(), out categoryId);
			return success ? (int?)categoryId : (int?)null;
		}
		private int? TrySelectProductByIDMenu(int сategoryId)
		{
			Console.Clear();
			productCommand.PrintAllProductsCommand(сategoryId);

			int productId;

			Console.Write("\nSelect the product id : ");

			bool success = int.TryParse(Console.ReadLine(), out productId);
			return success ? (int?)productId : (int?)null;
		}


		private void printDefaultSwitchStringMenu()
		{
			Console.WriteLine("\nWrong command selected");
		}
	}
}
