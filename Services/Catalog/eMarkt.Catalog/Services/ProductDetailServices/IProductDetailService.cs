using eMarkt.Catalog.Dtos.ProductDetailDtos;

namespace eMarkt.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        //Asenkron bir yapı kullanalım.
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);

        Task DeleteProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
    }
}
