using System;
using System.Collections.Generic;

namespace WebApplication4
{
    public partial class Courses
    {
        public Courses()
        {
            CourseeVents = new HashSet<CourseeVents>();
        }

        public string CourseId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<CourseeVents> CourseeVents { get; set; }
    }
}
