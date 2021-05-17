using HasanFurkanFidan.UdemyCourse.CATALOG.API.Dtos;
using HasanFurkanFidan.UdemyCourse.CATALOG.API.Models;
using HasanFurkanFidan.UdemyCourse.SHARED.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanFurkanFidan.UdemyCourse.CATALOG.API.Services.Abstract
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryAddDto>> AddAsync(Category category);
        Task<Response<CategoryDto>> GetByIdAsync(string id);
        Task<Response<CategoryUpdateDto>> UpdateAsync(Category category);
    }

}
