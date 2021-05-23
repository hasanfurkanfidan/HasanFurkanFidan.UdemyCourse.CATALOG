using AutoMapper;
using HasanFurkanFidan.UdemyCourse.CATALOG.API.CustomFilterAttributes;
using HasanFurkanFidan.UdemyCourse.CATALOG.API.Dtos;
using HasanFurkanFidan.UdemyCourse.CATALOG.API.Models;
using HasanFurkanFidan.UdemyCourse.CATALOG.API.Services.Abstract;
using HasanFurkanFidan.UdemyCourse.SHARED.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanFurkanFidan.UdemyCourse.CATALOG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _categoryService.GetAllAsync();
            return CreateActionResultInstance(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _categoryService.GetByIdAsync(id);
            return CreateActionResultInstance(response);
        }
        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> Add(CategoryAddDto model)
        {
            var response = await _categoryService.AddAsync(_mapper.Map<Category>(model));
            return CreateActionResultInstance(response);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _categoryService.DeleteAsync(id);
            return CreateActionResultInstance(response);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult>Update(CategoryUpdateDto model)
        {
            var response = await _categoryService.UpdateAsync(model);
            return CreateActionResultInstance(response);
            
        }
    }

}
