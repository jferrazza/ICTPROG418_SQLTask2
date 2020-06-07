using System;
using System.Collections.Generic;

namespace WebApplication4
{
    public partial class AlliNformation
    {
        public int Clientid { get; set; }
        public string Tourname { get; set; }
        public string Description { get; set; }
        public string Eventmonth { get; set; }
        public int Eventday { get; set; }
        public int Eventyear { get; set; }
        public int? Fee { get; set; }
        public DateTime Datebooked { get; set; }
        public int? Payment { get; set; }
    }
}
