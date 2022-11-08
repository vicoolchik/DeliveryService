using System;
using System.Collections.Generic;

#nullable disable

namespace DeliveryService.DAL.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Orders = new HashSet<Order>();
        }

        public int EmployeeId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Counrty { get; set; }
        public string Phone { get; set; }
        public string HomePhone { get; set; }
        public string BankCard { get; set; }
        public DateTime? RowInsertTime { get; set; }
        public DateTime? RowUpdateTime { get; set; }
        public string EmployeeLname { get; set; }
        public string EmployeeFname { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
