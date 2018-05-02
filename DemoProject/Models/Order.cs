using System;
using System.Collections.Generic;

namespace DemoProject.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public DateTime? DayCreate { get; set; }
        public double? Total { get; set; }

        public ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
