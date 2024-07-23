using BookStore.Dtos.CategoryDtos;
using BookStore.Services.CategoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService adminService)
        {
            _categoryService = adminService;
        }
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var categoryList = await _categoryService.GetAllCategoryAsync();
            return Ok(categoryList);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("kategori başarıyla oluşturuldu.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("kategori başarıyla güncellendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("kategori başarıyla silindi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCategory(int id)
        {
            var value = await _categoryService.GetByIdCategoryAsync(id);
            return Ok(value);
        }
    }

}