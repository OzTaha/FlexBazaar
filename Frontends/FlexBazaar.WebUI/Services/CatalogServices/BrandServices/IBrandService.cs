using FlexBazaar.DtoLayer.CatalogDtos.BrandDtos;

namespace FlexBazaar.WebUI.Services.CatalogServices.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllBrandAsync();
        Task CreateBrandAsync(CreateBrandDto createBrandDto);
        Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
        Task DeleteBrandAsync(string id);
        Task<UpdateBrandDto> GetByIdBrandAsync(string id);
    }
}
