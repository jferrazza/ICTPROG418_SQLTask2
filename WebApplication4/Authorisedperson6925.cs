using System;
using System.Collections.Generic;

namespace WebApplication4
{
    public partial class Authorisedperson6925
    {
        public Authorisedperson6925()
        {
            Order6925 = new HashSet<Order6925>();
        }

        public int Userid { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Accountid { get; set; }

        public virtual Clientaccount6925 Account { get; set; }
        public virtual ICollection<Order6925> Order6925 { get; set; }
    }
}
