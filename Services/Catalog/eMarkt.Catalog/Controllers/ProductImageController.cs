using eMarkt.Catalog.Dtos.ProductImageDtos;
using eMarkt.Catalog.Services.ProductImageServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eMarkt.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {   //constructor oluşturduk.Bir sınıfın başlangıç değerini oluşturmak, nesnesini oluşturmak için kullanılır.
        private readonly IProductImageService _categoryService;

        public ProductImageController(IProductImageService categoryService)
        {
            _categoryService = categoryService;
        }

      // Bir controller aksiyonundan gelen sonucu tanımlamak ve kullanıcıya geri döndürmek için kullanılır.
      // NotFound, OK, Redirect verilerini döndürür.

        [HttpGet]   
        public async Task<IActionResult> ProductImageList() 
        { 
        var values = await _categoryService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageByIdList(string id)
        {
            var values = await _categoryService.GetByIdProductImageAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            //Mapleme kullandığımız için new lememize gerek kalmadı.
            var values = _categoryService.CreateProductImageAsync(createProductImageDto);
            return Ok("Üren resmi eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            var values = _categoryService.DeleteProductImageAsync(id);
            return Ok("Üren resmi silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            var values = _categoryService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Üren resmi güncellendi.");
        }
    }
}
