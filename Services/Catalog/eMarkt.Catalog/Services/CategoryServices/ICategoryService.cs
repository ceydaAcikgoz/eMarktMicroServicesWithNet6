using eMarkt.Catalog.Dtos.CategoryDtos;
using eMarkt.Catalog.Entities;

namespace eMarkt.Catalog.Services.CategoryServices
{
    //İlgli işlemle ilgili ekleme, silme, güncelleme gibi crud işlemlerin yapıldığı methodları(imzaları) tutacak.
    public interface ICategoryService
    {
        //Asenkron bir yapı kullanalım.
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);      

        Task DeleteCategoryAsync(string id);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
    }
}
