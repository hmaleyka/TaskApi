using System.Linq.Expressions;
using testAPI.Entities;

namespace testAPI.Repositories.Interfaces
{
    public interface IRepository
    {
        Task<IQueryable<Category>> GetAll(Expression<Func<Category, bool>>? expression = null, params string[] includes);
        Task<Category> GetByIdAsync(int id);

        Task Create (Category category);
        void Update (Category category);
        void Delete (Category category);
        Task SaveChangesAsync();
      
    }
}
