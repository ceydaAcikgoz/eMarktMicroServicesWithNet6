using eMarkt.Catalog.Dtos.CategoryDtos;
using eMarkt.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eMarkt.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {   //constructor oluşturduk.Bir sınıfın başlangıç değerini oluşturmak, nesnesini oluşturmak için kullanılır.
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

      // Bir controller aksiyonundan gelen sonucu tanımlamak ve kullanıcıya geri döndürmek için kullanılır.
      // NotFound, OK, Content(), File(), Redirect verilerini döndürür.

        [HttpGet]   
        public async Task<IActionResult> CategoryList() 
        { 
        var values = await _categoryService.GetAllCategoryAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByIdList(string id)
        {
            var values = await _categoryService.GetByIdCategoryAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            //Mapleme kullandığımız için new lememize gerek kalmadı.
            var values =  _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("Kategori eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var values = _categoryService.DeleteCategoryAsync(id);
            return Ok("Kategori silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var values = _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Kategori güncellendi.");
        }
    }
}
