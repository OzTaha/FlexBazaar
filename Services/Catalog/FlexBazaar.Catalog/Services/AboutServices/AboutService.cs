using AutoMapper;
using FlexBazaar.Catalog.Dtos.AboutDtos;
using FlexBazaar.Catalog.Entities;
using FlexBazaar.Catalog.Settings;
using MongoDB.Driver;

namespace FlexBazaar.Catalog.Services.AboutServices
{
    public class AboutService:IAboutService
    {
        private readonly IMongoCollection<About> _aboutCollection;

        private readonly IMapper _mapper;

        public AboutService(IMapper mapper, IDatabaseSettings _databaseSetting)
        {
            var client = new MongoClient(_databaseSetting.ConnectioString);
            var database = client.GetDatabase(_databaseSetting.DatabaseName);
            _aboutCollection = database.GetCollection<About>(_databaseSetting.AboutCollectionName);
            _mapper = mapper;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            var value = _mapper.Map<About>(createAboutDto);
            await _aboutCollection.InsertOneAsync(value);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _aboutCollection.DeleteOneAsync(x => x.AboutId == id);
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            var values = await _aboutCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultAboutDto>>(values);
        }

        public async Task<GetByIdAboutDto> GetByIdAboutAsync(string id)
        {
            var values = await _aboutCollection.Find<About>(x => x.AboutId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdAboutDto>(values);
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var values = _mapper.Map<About>(updateAboutDto);
            await _aboutCollection.FindOneAndReplaceAsync(x => x.AboutId == updateAboutDto.AboutId, values);
        }
    }
}
