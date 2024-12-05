using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Application.DTOs.CategoryDTOs;
using SuperMarket.Application.Interfaces.IServices;

namespace SuperMarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _categoryService.GetAllCategories();
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("{id}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _categoryService.GetCategoryById(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> Create(CategoryCreateDTO createCategoryDTO)
        {
            var response = await _categoryService.CreateCategory(createCategoryDTO);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _categoryService.DeleteCategory(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> Update(CategoryUpdateDTO updateCategoryDTO, int id)
        {
            var response = await _categoryService.UpdateCategory(updateCategoryDTO, id);
            return StatusCode(response.StatusCode, response);
        }
    }
}