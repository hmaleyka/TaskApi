using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using testAPI.DAL;
using testAPI.Entities;
using testAPI.Repositories.Interfaces;

namespace testAPI.Repositories.Implementations
{
    public class Repository : IRepository
    {
        private AppDbContext _dbcontext;

        public Repository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task Create(Category category)
        {
            await _dbcontext.categories.AddAsync(category); 
        }

        public void Delete(Category category)
        {
            _dbcontext.categories.Remove(category);
        }

        public async Task SaveChangesAsync()
        {
           await  _dbcontext.SaveChangesAsync();
        }

        public void Update(Category category)
        {
            _dbcontext.categories.Update(category);
        }

        async Task<IQueryable<Category>> IRepository.GetAll(Expression<Func<Category, bool>>? expression = null ,params string[] includes)
        {
            IQueryable<Category> query = _dbcontext.categories;
           if(includes is not null) 
            {
                for(int i = 0; i<includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }

           if(expression is not null)
            {
                query = query.Where(expression);
            }
            
            return query;
        }

        async Task<Category> IRepository.GetByIdAsync(int id)
        {
            return await _dbcontext.categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
