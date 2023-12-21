using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testAPI.DAL;
using testAPI.DTOs;
using testAPI.Entities;
using testAPI.Repositories.Interfaces;
using testAPI.Services.Interfaces;

namespace testAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
     
        private readonly ICategoryRepository _repository;
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryRepository repository , ICategoryService service)
        {
           
            _repository = repository;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var category = await _service.GetAll();
            return StatusCode(StatusCodes.Status200OK, category);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {


            var categories = await _service.GetById(id);        
            return StatusCode(StatusCodes.Status200OK, categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateCategoryDto categorydto)
        {

           var category = await _service.Create(categorydto);
           
            return StatusCode(StatusCodes.Status201Created, category);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateCategoryDto updateCategoryDto)
        {
            var oldcategory = await _service.Update(id, updateCategoryDto);
            return StatusCode(StatusCodes.Status200OK, oldcategory);
               
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
           
            await  _service.Delete(id);

            return StatusCode(StatusCodes.Status200OK);
        }

    }
}
