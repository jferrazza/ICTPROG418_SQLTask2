using System;
using System.Collections.Generic;

namespace WebApplication4
{
    public partial class Location6925
    {
        public Location6925()
        {
            Inventory6925 = new HashSet<Inventory6925>();
            Purchaseorder6925 = new HashSet<Purchaseorder6925>();
        }

        public string Locationid { get; set; }
        public string Locname { get; set; }
        public string Address { get; set; }
        public string Manager { get; set; }

        public virtual ICollection<Inventory6925> Inventory6925 { get; set; }
        public virtual ICollection<Purchaseorder6925> Purchaseorder6925 { get; set; }
    }
}
