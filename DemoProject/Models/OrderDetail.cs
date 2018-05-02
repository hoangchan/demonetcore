using System;
using System.Collections.Generic;

namespace DemoProject.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public double? Total { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
