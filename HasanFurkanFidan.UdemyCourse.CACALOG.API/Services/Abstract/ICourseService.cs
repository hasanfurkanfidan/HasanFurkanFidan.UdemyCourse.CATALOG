using HasanFurkanFidan.UdemyCourse.CATALOG.API.Dtos;
using HasanFurkanFidan.UdemyCourse.CATALOG.API.Models;
using HasanFurkanFidan.UdemyCourse.SHARED.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanFurkanFidan.UdemyCourse.CATALOG.API.Services.Abstract
{
    public interface ICourseService
    {
        Task<Response<List<CourseDto>>> GetAllAsync();
        Task<Response<CourseAddDto>> AddAsync(Course course);
        Task<Response<CourseDto>> GetByIdAsync(string id);
        Task<Response<CourseUpdateDto>> UpdateAsync(Course course);
    }
}
