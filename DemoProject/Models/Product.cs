using System;
using System.Collections.Generic;

namespace DemoProject.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Detial { get; set; }
        public string Image { get; set; }
        public double? Price { get; set; }

        public ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
