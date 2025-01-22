using FlexBazaar.Catalog.Dtos.CategoryDtos;

// Bu interface, bir kategori sistemi için gerekli CRUD işlemlerini (Create, Read, Update, Delete) belirli bir standarda oturtmayı amaçlar. Her bir metod, kategorilerle ilgili spesifik bir işlemi temsil eder.
namespace FlexBazaar.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
    }
}
