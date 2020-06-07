using System;
using System.Collections.Generic;

namespace WebApplication4
{
    public partial class ToureVents
    {
        public ToureVents()
        {
            Bookings = new HashSet<Bookings>();
        }

        public string TourName { get; set; }
        public string EventMonth { get; set; }
        public int EventDay { get; set; }
        public int EventYear { get; set; }
        public int? Fee { get; set; }

        public virtual Tours TourNameNavigation { get; set; }
        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}
