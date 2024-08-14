using eMarkt.Discount.Dtos;

namespace eMarkt.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync();  
        Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto);  
        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto);  
        Task DeleteDiscountCouponAsync(int id);  
        Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsyns(int id);  
    }
}
