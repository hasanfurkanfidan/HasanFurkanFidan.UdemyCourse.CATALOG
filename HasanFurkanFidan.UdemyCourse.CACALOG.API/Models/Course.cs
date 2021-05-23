using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanFurkanFidan.UdemyCourse.CATALOG.API.Models
{
    public class Course
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string UserId { get; set; }

        public decimal Price { get; set; }
        public string Picture { get; set; }

        public DateTime Created { get; set; }
        public List<Feature> Features { get; set; }

    }
}
