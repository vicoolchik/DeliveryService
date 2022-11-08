using System;
using System.Collections.Generic;

#nullable disable

namespace DeliveryService.DAL.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public int SupplierId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Counrty { get; set; }
        public string Phone { get; set; }
        public DateTime? RowInsertTime { get; set; }
        public DateTime? RowUpdateTime { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
