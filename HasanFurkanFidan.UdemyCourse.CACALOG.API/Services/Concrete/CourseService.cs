using AutoMapper;
using HasanFurkanFidan.UdemyCourse.CATALOG.API.Dtos;
using HasanFurkanFidan.UdemyCourse.CATALOG.API.Models;
using HasanFurkanFidan.UdemyCourse.CATALOG.API.Services.Abstract;
using HasanFurkanFidan.UdemyCourse.CATALOG.API.Settings;
using HasanFurkanFidan.UdemyCourse.SHARED.Dtos;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanFurkanFidan.UdemyCourse.CATALOG.API.Services.Concrete
{
    public class CourseService : ICourseService
    {
        private readonly IMongoCollection<Course> _courseCollection;
        private readonly IMapper _mapper;
        public CourseService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient();
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _courseCollection = database.GetCollection<Course>(databaseSettings.CourseCollectionName);
            _mapper = mapper;
        }
        public async Task<Response<CourseAddDto>> AddAsync(Course course)
        {
            await _courseCollection.InsertOneAsync(course);
            return Response<CourseAddDto>.Success(_mapper.Map<CourseAddDto>(course),200);

        }

        public async Task<Response<List<CourseDto>>> GetAllAsync()
        {
            var coursesCursor = await _courseCollection.FindAsync(null);
            var courses = await coursesCursor.ToListAsync();
            return Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses),200);
        }

        public async Task<Response<CourseDto>> GetByIdAsync(string id)
        {
            var courseCursor = await _courseCollection.FindAsync(p => p.Id == id);
            var course = await courseCursor.FirstOrDefaultAsync();
            return Response<CourseDto>.Success(_mapper.Map<CourseDto>(course), 200);
        }

        public async Task<Response<CourseUpdateDto>> UpdateAsync(Course course)
        {
            await _courseCollection.ReplaceOneAsync(p=>p.Id == course.Id,course);
            return Response<CourseUpdateDto>.Success(_mapper.Map<CourseUpdateDto>(course), 200);

        }
    }
}
