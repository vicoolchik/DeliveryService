using System;
using System.Collections.Generic;

#nullable disable

namespace DeliveryService.DAL.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Counrty { get; set; }
        public string Phone { get; set; }
        public DateTime? RowInsertTime { get; set; }
        public DateTime? RowUpdateTime { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
