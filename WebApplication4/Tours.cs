using System;
using System.Collections.Generic;

namespace WebApplication4
{
    public partial class Tours
    {
        public Tours()
        {
            ToureVents = new HashSet<ToureVents>();
        }

        public string TourName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ToureVents> ToureVents { get; set; }
    }
}
