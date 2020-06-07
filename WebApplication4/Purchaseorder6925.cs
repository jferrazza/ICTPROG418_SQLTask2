using System;
using System.Collections.Generic;

namespace WebApplication4
{
    public partial class Purchaseorder6925
    {
        public int Productid { get; set; }
        public string Locationid { get; set; }
        public DateTime Datetimecreated { get; set; }
        public int? Quantity { get; set; }
        public decimal? Total { get; set; }

        public virtual Location6925 Location { get; set; }
        public virtual Product6925 Product { get; set; }
    }
}
