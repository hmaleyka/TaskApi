using testAPI.DTOs;

namespace testAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IQueryable<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<Category> Create (CreateCategoryDto createCategoryDto);

        Task<Category> Update(int id, UpdateCategoryDto updateCategoryDto);

        Task<Category> Delete (int id);
    }
}
