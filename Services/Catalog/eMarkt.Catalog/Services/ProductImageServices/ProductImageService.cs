using AutoMapper;
using eMarkt.Catalog.Dtos.ProductImageDtos;
using eMarkt.Catalog.Entities;
using eMarkt.Catalog.Settings;
using MongoDB.Driver;

namespace eMarkt.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var values= _mapper.Map<ProductImage>(createProductImageDto); 
            await _productImageCollection.InsertOneAsync(values);    
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productImageCollection.DeleteOneAsync(x=>x.ProductImagesId == id);    
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _productImageCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values); 

        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var values = await _productImageCollection.Find<ProductImage>(x=>x.ProductImagesId == id).FirstOrDefaultAsync();  
            return _mapper.Map<GetByIdProductImageDto>(values); 
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var values = _mapper.Map<ProductImage>(updateProductImageDto);
            await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImagesId == updateProductImageDto.ProductImagesId, values);
           
        }
    }
}
