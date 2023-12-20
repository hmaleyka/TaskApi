namespace testAPI.Repositories.Implementations
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
