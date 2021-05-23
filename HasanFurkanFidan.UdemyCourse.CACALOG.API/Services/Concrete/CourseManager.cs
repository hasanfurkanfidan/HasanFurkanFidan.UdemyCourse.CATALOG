using AutoMapper;
using HasanFurkanFidan.UdemyCourse.CATALOG.API.Data.Abstract;
using HasanFurkanFidan.UdemyCourse.CATALOG.API.Dtos;
using HasanFurkanFidan.UdemyCourse.CATALOG.API.Models;
using HasanFurkanFidan.UdemyCourse.CATALOG.API.Services.Abstract;
using HasanFurkanFidan.UdemyCourse.SHARED.DataAccess.Spesification;
using HasanFurkanFidan.UdemyCourse.SHARED.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanFurkanFidan.UdemyCourse.CATALOG.API.Services.Concrete
{
    public class CourseManager : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public CourseManager(ICourseRepository courseRepository, IMapper mapper,ICategoryService categoryService)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
            _categoryService = categoryService;
        }
        public async Task<Response<CourseAddDto>> AddAsync(Course course)
        {
            await _courseRepository.AddAsync(course);
            return Response<CourseAddDto>.Success(_mapper.Map<CourseAddDto>(course), 200);
        }

        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null)
            {
                var errors = new List<string>();
                errors.Add("No valid course!");
                return Response<NoContent>.Fail(errors,404);
            }
            await _courseRepository.DeleteAsync(course);
            return Response<NoContent>.Success(200, true);
        }

        public async Task<Response<List<CourseDto>>> GetAllAsync()
        {
            var courses = await _courseRepository.GetListAsync(null);
            return Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), 200);
        }

        public async Task<Response<CourseDto>> GetByIdAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            return Response<CourseDto>.Success(_mapper.Map<CourseDto>(course), 200);
        }

        public async Task<Response<List<CourseDto>>> GetCoursesWithFeatureAsync()
        {
            var spesification = new BaseSpesification<Course>(null);
            spesification.AddInclude(p => p.Features);
            var courses = await _courseRepository.GetListWithSpecQuery(spesification);
            return Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(CourseUpdateDto model)
        {
            var course = await _courseRepository.GetByIdAsync(model.Id);
            if (course == null)
            {
                var errors = new List<string>();
                errors.Add("No valid course!");
                return Response<NoContent>.Fail(errors, 404);
            }
            await _courseRepository.UpdateAsync(_mapper.Map<Course>(model));
            return Response<NoContent>.Success(200, true);

        }
        public async Task<Response< List<CourseDto>>> GetByCategoryIdAsync(int id)
        {
            var categoryResponse = await _categoryService.GetByIdAsync(id);
            if (categoryResponse.StatusCode==404)
            {
                var errors = new List<string>();
                errors.Add("No category!");
                return Response<List<CourseDto>>.Fail(errors.FirstOrDefault(), 404);
            }
            var spesification = new BaseSpesification<Course>(p => p.CategoryId == id);
            spesification.AddInclude(p => p.Category);
            var courses = await _courseRepository.GetListWithSpecQuery(spesification);
            return Response<List<CourseDto>>.Success(_mapper.Map< List<CourseDto>>(courses),200);
        }
    }
}
