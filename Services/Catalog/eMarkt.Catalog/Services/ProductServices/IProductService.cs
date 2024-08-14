using eMarkt.Catalog.Dtos.ProductDtos;

namespace eMarkt.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        //Asenkron bir yapı kullanalım.
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);

        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
    }
}
