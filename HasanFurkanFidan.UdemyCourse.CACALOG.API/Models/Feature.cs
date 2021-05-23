using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanFurkanFidan.UdemyCourse.CATALOG.API.Models
{
    public class Feature
    {
        public int Id { get; set; }
        public int Duration { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}
