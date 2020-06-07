using System;
using System.Collections.Generic;

namespace WebApplication4
{
    public partial class Staffallocation
    {
        public int? Semid { get; set; }
        public int? Stfid { get; set; }

        public virtual Seminar Sem { get; set; }
        public virtual Staff Stf { get; set; }
    }
}
