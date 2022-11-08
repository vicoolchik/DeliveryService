using DeliveryService.DTO;
using System.Collections.Generic;

namespace DeliveryService.DAL.Interfaces
{
    public interface ISupplierDal
    {
        List<SupplierDTO> GetAllSuppliers();
    }
}
