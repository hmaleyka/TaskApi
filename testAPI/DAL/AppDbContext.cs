using Microsoft.EntityFrameworkCore;
using testAPI.Entities;

namespace testAPI.DAL
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) :base(options)
        {
                
        }

        public DbSet<Category> categories { get; set; }
    }
}
