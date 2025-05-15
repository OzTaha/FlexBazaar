using AutoMapper;
using FlexBazaar.Catalog.Dtos.ContactDtos;
using FlexBazaar.Catalog.Entities;
using FlexBazaar.Catalog.Settings;
using MongoDB.Driver;

namespace FlexBazaar.Catalog.Services.ContactServices
{
    public class ContactService:IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;

        private readonly IMapper _mapper;

        public ContactService(IMapper mapper, IDatabaseSettings _databaseSetting)
        {
            var client = new MongoClient(_databaseSetting.ConnectioString);
            var database = client.GetDatabase(_databaseSetting.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(_databaseSetting.ContactCollectionName);
            _mapper = mapper;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            var value = _mapper.Map<Contact>(createContactDto);
            await _contactCollection.InsertOneAsync(value);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _contactCollection.DeleteOneAsync(x => x.ContactId == id);
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var values = await _contactCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultContactDto>>(values);
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var values = await _contactCollection.Find<Contact>(x => x.ContactId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdContactDto>(values);
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            var values = _mapper.Map<Contact>(updateContactDto);
            await _contactCollection.FindOneAndReplaceAsync(x => x.ContactId == updateContactDto.ContactId, values);
        }
    }
}
