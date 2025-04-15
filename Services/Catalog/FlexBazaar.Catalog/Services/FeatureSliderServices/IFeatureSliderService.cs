using FlexBazaar.Catalog.Dtos.FeatureSliderDtos;

namespace FlexBazaar.Catalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
        Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
        Task DeleteFeatureSliderAsync(string id);
        Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id);
        // feature slider türünü true'ye dönüştürecek.
        Task FeatureSliderChangeStatusToTrue(string id);
        // feature slider türünü false'ye dönüştürecek.
        Task FeatureSliderChangeStatusToFalse(string id);
    }
}
