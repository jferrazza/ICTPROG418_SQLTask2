using System;
using System.Collections.Generic;

namespace WebApplication4
{
    public partial class Bookings
    {
        public int ClientId { get; set; }
        public string TourName { get; set; }
        public string EventMonth { get; set; }
        public int EventDay { get; set; }
        public int EventYear { get; set; }
        public int? Payment { get; set; }
        public DateTime DateBooked { get; set; }

        public virtual Clients Client { get; set; }
        public virtual ToureVents ToureVents { get; set; }
    }
}
