using AutoMapper;
using FlexBazaar.Catalog.Dtos.CategoryDtos;
using FlexBazaar.Catalog.Entities;
using FlexBazaar.Catalog.Settings;
using MongoDB.Driver;


//  CategoryService sınıfı, ICategoryService'de tanımlı olan kategori işlemlerini (CRUD) gerçekleştiren bir servis katmanıdır.
//  Veritabanı işlemleri(MongoDB) ve veri dönüşümleri (AutoMapper) için gerekli bağımlılıkları içerir.
namespace FlexBazaar.Catalog.Services.CategoryServices
{
    // Bu class, ICategoryService interface'ini implement ediyor.
    public class CategoryService : ICategoryService
    {
        // IMongoCollection<Category>: MongoDB'deki Category koleksiyonunu temsil eder.
        // Veritabanı işlemleri bu koleksiyon üzerinden yapılacaktır.
        private readonly IMongoCollection<Category> _categoryCollection;

        // IMapper: Veri transfer objeleri (DTO'lar) ile Entity'ler arasında otomatik dönüşüm yapmayı sağlayan bir araçtır.
        private readonly IMapper _mapper;

        //rvis çalışabilmesi için MongoDB koleksiyonu ve AutoMapper nesnesine ihtiyaç duyar. Bu bağımlılıklar, dependency injection (DI) kullanılarak constructor aracılığıyla alınır:
        public CategoryService(IMapper mapper, IDatabaseSettings _databaseSetting)
        {
            // MongoClient database bağlantısı için kullanılır.
            // GetDatabase bağlanılan databaseyi temsil eder.
            // GetCollection belirtilen collection'a erişim sağlar.
            var client = new MongoClient(_databaseSetting.ConnectioString);
            var database = client.GetDatabase(_databaseSetting.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSetting.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
           var value= _mapper.Map<Category>(createCategoryDto);
             await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
           await _categoryCollection.DeleteOneAsync(x => x.CategoryId == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
          var values = await _categoryCollection.Find<Category>(x => x.CategoryId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(values);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var values = _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDto.CategoryId, values);
        }
    }
}
