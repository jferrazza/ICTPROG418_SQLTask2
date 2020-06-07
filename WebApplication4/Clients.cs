using System;
using System.Collections.Generic;

namespace WebApplication4
{
    public partial class Clients
    {
        public Clients()
        {
            Bookings = new HashSet<Bookings>();
        }

        public int ClientId { get; set; }
        public string Surname { get; set; }
        public string GivenName { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}
