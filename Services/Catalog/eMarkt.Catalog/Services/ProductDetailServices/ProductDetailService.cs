using AutoMapper;
using eMarkt.Catalog.Dtos.ProductDetailDtos;
using eMarkt.Catalog.Entities;
using eMarkt.Catalog.Settings;
using MongoDB.Driver;
using static MongoDB.Driver.WriteConcern;

namespace eMarkt.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var values= _mapper.Map<ProductDetail>(createProductDetailDto); 
            await _productCollection.InsertOneAsync(values);    
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x=>x.ProductDetailId == id);    
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await _productCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(values); 

        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var values = await _productCollection.Find<ProductDetail>(x=>x.ProductDetailId == id).FirstOrDefaultAsync();  
            return _mapper.Map<GetByIdProductDetailDto>(values); 
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var values = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductDetailId == updateProductDetailDto.ProductDetailId, values);
           
        }
    }
}
