using HasanFurkanFidan.UdemyCourse.CATALOG.API.Data.Abstract;
using HasanFurkanFidan.UdemyCourse.CATALOG.API.Models;
using HasanFurkanFidan.UdemyCourse.SHARED.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanFurkanFidan.UdemyCourse.CATALOG.API.Data.Concrete
{
    public class CourseRepository:GenericRepository<Course,Context>,ICourseRepository
    {
    }
}
