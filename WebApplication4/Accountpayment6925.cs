using System;
using System.Collections.Generic;

namespace WebApplication4
{
    public partial class Accountpayment6925
    {
        public int Accountid { get; set; }
        public DateTime Datetimereceived { get; set; }
        public decimal Amount { get; set; }

        public virtual Clientaccount6925 Account { get; set; }
    }
}
