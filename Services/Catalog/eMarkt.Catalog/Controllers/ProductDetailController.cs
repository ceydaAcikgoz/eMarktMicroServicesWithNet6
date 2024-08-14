using eMarkt.Catalog.Dtos.ProductDetailDtos;
using eMarkt.Catalog.Services.ProductDetailServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eMarkt.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {   //constructor oluşturduk.Bir sınıfın başlangıç değerini oluşturmak, nesnesini oluşturmak için kullanılır.
        private readonly IProductDetailService _categoryService;

        public ProductDetailController(IProductDetailService categoryService)
        {
            _categoryService = categoryService;
        }

      // Bir controller aksiyonundan gelen sonucu tanımlamak ve kullanıcıya geri döndürmek için kullanılır.
      // NotFound, OK, Redirect verilerini döndürür.

        [HttpGet]   
        public async Task<IActionResult> ProductDetailList() 
        { 
        var values = await _categoryService.GetAllProductDetailAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailByIdList(string id)
        {
            var values = await _categoryService.GetByIdProductDetailAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            //Mapleme kullandığımız için new lememize gerek kalmadı.
            var values = _categoryService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Ürün detayı eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            var values = _categoryService.DeleteProductDetailAsync(id);
            return Ok("Ürün detayı silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            var values = _categoryService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Ürün detayı güncellendi.");
        }
    }
}
