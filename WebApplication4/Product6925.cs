using System;
using System.Collections.Generic;

namespace WebApplication4
{
    public partial class Product6925
    {
        public Product6925()
        {
            Inventory6925 = new HashSet<Inventory6925>();
            Orderline6925 = new HashSet<Orderline6925>();
            Purchaseorder6925 = new HashSet<Purchaseorder6925>();
        }

        public int Productid { get; set; }
        public string Prodname { get; set; }
        public decimal? Buyprice { get; set; }
        public decimal? Sellprice { get; set; }

        public virtual ICollection<Inventory6925> Inventory6925 { get; set; }
        public virtual ICollection<Orderline6925> Orderline6925 { get; set; }
        public virtual ICollection<Purchaseorder6925> Purchaseorder6925 { get; set; }
    }
}
