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
            return new Response<CourseAddDto>.
        }

        public Task<Response<List<CourseDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<CourseDto>> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<CourseUpdateDto>> UpdateAsync(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
