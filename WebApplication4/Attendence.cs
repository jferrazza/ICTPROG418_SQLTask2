using System;
using System.Collections.Generic;

namespace WebApplication4
{
    public partial class Attendence
    {
        public int? Score { get; set; }
        public int? Stuid { get; set; }
        public int? Semid { get; set; }

        public virtual Seminar Sem { get; set; }
        public virtual Student Stu { get; set; }
    }
}
