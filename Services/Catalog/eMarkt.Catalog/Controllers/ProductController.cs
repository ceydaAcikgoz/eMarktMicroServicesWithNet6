using eMarkt.Catalog.Dtos.ProductDtos;
using eMarkt.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eMarkt.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {   //constructor oluşturduk.Bir sınıfın başlangıç değerini oluşturmak, nesnesini oluşturmak için kullanılır.
        private readonly IProductService _categoryService;

        public ProductController(IProductService categoryService)
        {
            _categoryService = categoryService;
        }

      // Bir controller aksiyonundan gelen sonucu tanımlamak ve kullanıcıya geri döndürmek için kullanılır.
      // NotFound, OK, Redirect verilerini döndürür.

        [HttpGet]   
        public async Task<IActionResult> ProductList() 
        { 
        var values = await _categoryService.GetAllProductAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdList(string id)
        {
            var values = await _categoryService.GetByIdProductAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            //Mapleme kullandığımız için new lememize gerek kalmadı.
            var values = _categoryService.CreateProductAsync(createProductDto);
            return Ok("Ürün eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var values = _categoryService.DeleteProductAsync(id);
            return Ok("Ürün silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var values = _categoryService.UpdateProductAsync(updateProductDto);
            return Ok("Ürün güncellendi.");
        }
    }
}
