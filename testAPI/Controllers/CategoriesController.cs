using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testAPI.DAL;
using testAPI.DTOs;
using testAPI.Entities;
using testAPI.Repositories.Interfaces;

namespace testAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private AppDbContext _dbcontext;
        private readonly IRepository _repository;

        public CategoriesController(AppDbContext dbcontext, IRepository repository)
        {
           _dbcontext = dbcontext;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var category = await _repository.GetAll();
            return StatusCode(StatusCodes.Status200OK, category);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            var categories = await _repository.GetByIdAsync(id);

            if(categories==null) return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(StatusCodes.Status200OK, categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateCategoryDto categorydto)
        {

            Category category = new Category()
            {
                Name = categorydto.Name,
            };
            await _repository.Create(category);
            await _repository.SaveChangesAsync();
           
            return StatusCode(StatusCodes.Status201Created, category);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, string name)
        {
            if(id<=0) return StatusCode(StatusCodes.Status400BadRequest);
            var categories = await _repository.GetByIdAsync(id);

            
            if (categories == null) return StatusCode(StatusCodes.Status404NotFound);
           
            categories.Name = name;
            _repository.Update(categories);
            await _repository.SaveChangesAsync();
           

            return StatusCode(StatusCodes.Status200OK, categories);
               
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var categories = _dbcontext.categories.FirstOrDefault(c => c.Id == id);
            _dbcontext.Remove(categories);
            _dbcontext.SaveChanges();

            return StatusCode(StatusCodes.Status200OK, categories);
        }

    }
}
