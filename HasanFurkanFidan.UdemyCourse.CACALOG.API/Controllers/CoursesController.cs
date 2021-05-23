using AutoMapper;
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
    public class CoursesController : CustomBaseController
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;
        public CoursesController(ICourseService courseService,IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courseResponse = await _courseService.GetAllAsync();
            return CreateActionResultInstance(response:courseResponse);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var response = await _courseService.GetByIdAsync(id);
            return CreateActionResultInstance(response);
        }
        [HttpPost]
        public async Task<IActionResult>Add(CourseAddDto model)
        {
            var response = await _courseService.AddAsync(_mapper.Map<Course>(model));
            return CreateActionResultInstance(response);
        }
        [HttpDelete("id")]
        public async Task<IActionResult>Delete(int id)
        {
            var response = await _courseService.DeleteAsync(id);
            return CreateActionResultInstance(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(CourseUpdateDto model)
        {
            var response = await _courseService.UpdateAsync(model);
            return CreateActionResultInstance(response);
        }
        [HttpGet("getwithcategory")]
        public async Task<IActionResult>GetWithCategory(int categoryId)
        {
            var response = await _courseService.GetByCategoryIdAsync(categoryId);
            return CreateActionResultInstance(response);
        }
    }
}
