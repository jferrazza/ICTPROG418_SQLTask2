using System;
using System.Collections.Generic;

namespace WebApplication4
{
    public partial class Worker
    {
        public int Wid { get; set; }
        public string Wname { get; set; }
        public string Gender { get; set; }
        public int? Project { get; set; }

        public virtual Project ProjectNavigation { get; set; }
    }
}
