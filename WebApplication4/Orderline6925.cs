using System;
using System.Collections.Generic;

namespace WebApplication4
{
    public partial class Orderline6925
    {
        public int Orderid { get; set; }
        public int Productid { get; set; }
        public int Quantity { get; set; }
        public decimal? Discount { get; set; }
        public decimal Subtotal { get; set; }

        public virtual Order6925 Order { get; set; }
        public virtual Product6925 Product { get; set; }
    }
}
