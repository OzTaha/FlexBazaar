using AutoMapper;
using FlexBazaar.Catalog.Dtos.ProductImageDtos;
using FlexBazaar.Catalog.Entities;
using FlexBazaar.Catalog.Settings;
using MongoDB.Driver;

namespace FlexBazaar.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _ProductImageCollection;

        // IMapper: Veri transfer objeleri (DTO'lar) ile Entity'ler arasında otomatik dönüşüm yapmayı sağlayan bir araçtır.
        private readonly IMapper _mapper;

        //servis çalışabilmesi için MongoDB koleksiyonu ve AutoMapper nesnesine ihtiyaç duyar. Bu bağımlılıklar, dependency injection (DI) kullanılarak constructor aracılığıyla alınır:
        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSetting)
        {
            // MongoClient database bağlantısı için kullanılır.
            // GetDatabase bağlanılan databaseyi temsil eder.
            // GetCollection belirtilen collection'a erişim sağlar.
            var client = new MongoClient(_databaseSetting.ConnectioString);
            var database = client.GetDatabase(_databaseSetting.DatabaseName);
            _ProductImageCollection = database.GetCollection<ProductImage>(_databaseSetting.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var value =  _mapper.Map<ProductImage>(createProductImageDto);
            await _ProductImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _ProductImageCollection.DeleteOneAsync(x => x.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _ProductImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var values = await _ProductImageCollection.Find<ProductImage>(x => x.ProductImageId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(values);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var values = _mapper.Map<ProductImage>(updateProductImageDto);
            await _ProductImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImageDto.ProductImageId, values);
        }
    }
}
