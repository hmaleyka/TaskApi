using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testAPI.DAL;
using testAPI.Entities;

namespace testAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private AppDbContext _dbcontext;

        public CategoriesController(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Category> category = await _dbcontext.categories.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, category);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            var categories = await _dbcontext.categories.FirstOrDefaultAsync(c => c.Id == id);

            if(categories==null) return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(StatusCodes.Status200OK, categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            await _dbcontext.categories.AddAsync(category);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, category);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, string name)
        {
            if(id<=0) return StatusCode(StatusCodes.Status400BadRequest);
            var categories = await _dbcontext.categories.FirstOrDefaultAsync(c=>c.Id == id);

            
            if (categories == null) return StatusCode(StatusCodes.Status404NotFound);
           
            categories.Name = name;
            await _dbcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, categories);
               
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var categories = _dbcontext.categories.FirstOrDefault(c=>c.Id == id);
            _dbcontext.Remove(categories);
            _dbcontext.SaveChanges();

            return StatusCode(StatusCodes.Status200OK, categories);
        }

    }
}
