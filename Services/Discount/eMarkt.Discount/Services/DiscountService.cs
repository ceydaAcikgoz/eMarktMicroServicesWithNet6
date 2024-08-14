using Dapper;
using eMarkt.Discount.Context;
using eMarkt.Discount.Dtos;

namespace eMarkt.Discount.Services
{
    public class DiscountService: IDiscountService
    {
       private readonly DapperContext _dapperContext;  

        public DiscountService(DapperContext context)
        {
            _dapperContext = context;
        }
        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto)
        {
            string query = "insert into Coupons (Code, Rate, IsActive, ValidDate) values (@code, @rate, @isActive, @validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("code", createDiscountCouponDto.Code);
            parameters.Add("rate", createDiscountCouponDto.Rate);
            parameters.Add("isActive", createDiscountCouponDto.IsActive);
            parameters.Add("validDate", createDiscountCouponDto.ValidDate);

            using(var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);   
            }
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "delete from Coupons where CouponId = @couponId";
            var parameters = new DynamicParameters();   
            parameters.Add("couponId", id);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "Select * From Coupons";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);    
                return values.ToList();
            }
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsyns(int id)
        {
            string query = "Select * From Coupons where CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId", id);

            using (var connection = _dapperContext.CreateConnection())
            {
               var values=  await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query);
                return values;
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto)
        {
            string query = "Update Coupons Set (Code=@code, Rate=, IsActive=@isActive, ValidDate=@validDate) where  CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("code", updateDiscountCouponDto.Code);
            parameters.Add("rate", updateDiscountCouponDto.Rate);
            parameters.Add("isActive", updateDiscountCouponDto.IsActive);
            parameters.Add("validDate", updateDiscountCouponDto.ValidDate);
            parameters.Add("couponId", updateDiscountCouponDto.CouponId);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
