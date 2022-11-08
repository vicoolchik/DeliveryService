using System;
using System.Collections.Generic;

#nullable disable

namespace DeliveryService.DAL.Models
{
    public partial class Orderdetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public DateTime? RowInsertTime { get; set; }
        public DateTime? RowUpdateTime { get; set; }
        public int OrderdetailsId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
