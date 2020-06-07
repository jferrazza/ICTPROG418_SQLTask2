using System;
using System.Collections.Generic;

namespace WebApplication4
{
    public partial class CourseeVents
    {
        public string CourseId { get; set; }
        public string EventMonth { get; set; }
        public int EventDay { get; set; }
        public int EventYear { get; set; }
        public int? Fee { get; set; }

        public virtual Courses Course { get; set; }
    }
}
