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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<Response<CategoryAddDto>> AddAsync(Category category)
        {
            await _categoryRepository.AddAsync(category);
            return Response<CategoryAddDto>.Success(_mapper.Map<CategoryAddDto>(category), 200);
        }

        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
           
            await _categoryRepository.DeleteAsync(category);
            return Response<NoContent>.Success(200, true);
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var spesification = new BaseSpesification<Category>(null);
            spesification.AddInclude(p => p.Courses);
            var categories = await _categoryRepository.GetListWithSpecQuery(spesification);
            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);
        }



        public async Task<Response<CategoryDto>> GetByIdAsync(int id)
        {
            var spesification = new BaseSpesification<Category>(p => p.Id == id);
            spesification.AddInclude(p => p.Courses);
            var category = await _categoryRepository.GetWithSpecQuery(spesification);
            if (category == null)
            {
                var errors = new List<string>();
                errors.Add("Category Not Found!");
                return Response<CategoryDto>.Fail(errors, 404);

            }
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(CategoryUpdateDto model)
        {
            var category = await _categoryRepository.GetByIdAsync(model.Id);
            if (category == null)
            {
                var errors = new List<string>();
                errors.Add("Category Not Found!");
                return Response<NoContent>.Fail(errors, 404);

            }
            await _categoryRepository.UpdateAsync(_mapper.Map<Category>(model));
            return Response<NoContent>.Success(200, true);

        }
    }
}
