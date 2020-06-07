using System;
using System.Collections.Generic;

namespace WebApplication4
{
    public partial class Order6925
    {
        public Order6925()
        {
            Orderline6925 = new HashSet<Orderline6925>();
        }

        public int Orderid { get; set; }
        public string Shippingaddress { get; set; }
        public DateTime Datetimecreated { get; set; }
        public DateTime? Datetimedispatched { get; set; }
        public decimal Total { get; set; }
        public int Userid { get; set; }

        public virtual Authorisedperson6925 User { get; set; }
        public virtual ICollection<Orderline6925> Orderline6925 { get; set; }
    }
}
