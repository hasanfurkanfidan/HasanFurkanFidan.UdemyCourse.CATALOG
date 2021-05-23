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
        Task<Response<List<CourseDto>>> GetCoursesWithFeatureAsync();
        Task<Response<CourseAddDto>> AddAsync(Course course);
        Task<Response<CourseDto>> GetByIdAsync(int id);
        Task<Response<NoContent>> UpdateAsync(CourseUpdateDto model);
        Task<Response<NoContent>>DeleteAsync(int id);
        Task<Response<List<CourseDto>>> GetByCategoryIdAsync(int id);

    }
}
