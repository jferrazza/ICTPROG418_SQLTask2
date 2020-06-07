using System;
using System.Collections.Generic;

namespace WebApplication4
{
    public partial class Clientaccount6925
    {
        public Clientaccount6925()
        {
            Accountpayment6925 = new HashSet<Accountpayment6925>();
            Authorisedperson6925 = new HashSet<Authorisedperson6925>();
        }

        public int Accountid { get; set; }
        public string Acctname { get; set; }
        public decimal Balance { get; set; }
        public decimal Creditlimit { get; set; }

        public virtual ICollection<Accountpayment6925> Accountpayment6925 { get; set; }
        public virtual ICollection<Authorisedperson6925> Authorisedperson6925 { get; set; }
    }
}
