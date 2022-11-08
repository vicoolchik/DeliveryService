using AutoMapper;
using DeliveryService.DAL.Interfaces;
using DeliveryService.DAL.Models;
using DeliveryService.DTO;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryService.DAL.Concrete
{
    public class SupplierDal: ISupplierDal
    {
        private readonly IMapper _mapper;
        public SupplierDal(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<SupplierDTO> GetAllSuppliers()
        {
            using (var entities = new ProductcompanyContext())
            {
                var suppliers = entities.Suppliers.ToList();
                return _mapper.Map<List<SupplierDTO>>(suppliers);
            }
        }
    }
}
