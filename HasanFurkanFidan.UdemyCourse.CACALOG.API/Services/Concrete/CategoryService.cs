using AutoMapper;
using HasanFurkanFidan.UdemyCourse.CATALOG.API.Dtos;
using HasanFurkanFidan.UdemyCourse.CATALOG.API.Models;
using HasanFurkanFidan.UdemyCourse.CATALOG.API.Services.Abstract;
using HasanFurkanFidan.UdemyCourse.CATALOG.API.Settings;
using HasanFurkanFidan.UdemyCourse.SHARED.Dtos;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanFurkanFidan.UdemyCourse.CATALOG.API.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;
        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.CategoryCollectionName);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;


        }
        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categoriesCursor = await _categoryCollection.FindAsync(null);
            var categories = await categoriesCursor.ToListAsync();
            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);
        }
        public async Task<Response<CategoryAddDto>> AddAsync(Category category)
        {
            await _categoryCollection.InsertOneAsync(category);
            return Response<CategoryAddDto>.Success(_mapper.Map<CategoryAddDto>(category),200);
        }
        public async Task<Response<CategoryDto>>GetByIdAsync(string id)
        {
            var categoryCursor = await _categoryCollection.FindAsync(p => p.Id == id);
            var category = categoryCursor.FirstOrDefaultAsync();
            if (category==null)
            {
                return Response<CategoryDto>.Fail("Category Not Fount", 404);
            }
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }
        public async Task<Response<CategoryUpdateDto>>UpdateAsync(Category category)
        {
            await _categoryCollection.ReplaceOneAsync(p => p.Id == category.Id, category) ;
            return Response<CategoryUpdateDto>.Success(_mapper.Map<CategoryUpdateDto>(category), 200);

        }
       
    }
}
