using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanFurkanFidan.UdemyCourse.CATALOG.API.Dtos
{
    public class CourseAddDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string Picture { get; set; }

        public string UserId { get; set; }
        public decimal Price { get; set; }
    }
}
