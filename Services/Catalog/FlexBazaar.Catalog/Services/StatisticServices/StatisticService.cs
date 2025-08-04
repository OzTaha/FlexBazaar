using AutoMapper;
using FlexBazaar.Catalog.Entities;
using FlexBazaar.Catalog.Settings;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FlexBazaar.Catalog.Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Brand> _brandCollection;

        public StatisticService(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectioString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);            
        }
        // Bu metot, MongoDB’deki bir koleksiyonda (“_brandCollection”) kaç adet belge (document) olduğunu sayıp geri döndürür. 
        public async Task<long> GetBrandCount()
        {

            // FilterDefinition<Brand>.Empty, tüm belgeleri seçer. Yani herhangi bir filtre uygulamadan koleksiyondaki tüm belgeleri sayar.
            return await _brandCollection.CountDocumentsAsync(FilterDefinition<Brand>.Empty);
        }

        public Task<long> GetCategoryCount()
        {
            return _categoryCollection.CountDocumentsAsync(FilterDefinition<Category>.Empty);
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Descending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y =>
                                                         y.ProductName).Exclude("ProductId");
            var product = await _productCollection.Find(filter)
                                                   .Sort(sort)
                                                   .Project(projection)
                                                   .FirstOrDefaultAsync();
            return product.GetValue("ProductName").AsString;
        }

        public async Task<string> GetMinPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Ascending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y =>
                                                         y.ProductName).Exclude("ProductId");
            var product = await _productCollection.Find(filter)
                                                   .Sort(sort)
                                                   .Project(projection)
                                                   .FirstOrDefaultAsync();
            return product.GetValue("ProductName").AsString;
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            var pipeline = new BsonDocument[]
            {
               new BsonDocument("$group", new BsonDocument
               {
                   {"_id", BsonNull.Value},
                   {"averagePrice", new BsonDocument("$avg", "$ProductPrice")}
               })
            };
            var result = await _productCollection.AggregateAsync<BsonDocument>(pipeline);
            var price = result.FirstOrDefault().GetValue("averagePrice", decimal.Zero).AsDecimal;
            return price;
        }

        public Task<long> GetProductCount()
        {
            return _productCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);
        }        
    }
}
