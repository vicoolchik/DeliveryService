using AutoMapper;
using DeliveryService.DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.CommandRepository
{
    class SupplierCommand
    {
        static IMapper Mapper = SetupMapper();

        private static IMapper SetupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(SupplierDal).Assembly)
                );
            return config.CreateMapper();
        }  
        
        internal void PrintAllSuppliersCommand()
        {
            var dal = new SupplierDal(Mapper);
            var suppliersList = dal.GetAllSuppliers();

            Console.WriteLine("\nSuppliers Name\n");
            foreach (var supplier in suppliersList)
            {
                Console.WriteLine(supplier.ToString());
            }
        }

    }
}
