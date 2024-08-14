using eMarkt.Catalog.Dtos.ProductImageDtos;

namespace eMarkt.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        //Asenkron bir yapı kullanalım.
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);

        Task DeleteProductImageAsync(string id);
        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
    }
}
