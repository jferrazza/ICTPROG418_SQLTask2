using System;
using System.Collections.Generic;

namespace WebApplication4
{
    public partial class Project
    {
        public Project()
        {
            Worker = new HashSet<Worker>();
        }

        public int ProjCode { get; set; }
        public string ProjectTitle { get; set; }

        public virtual ICollection<Worker> Worker { get; set; }
    }
}
