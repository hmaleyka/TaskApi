using AutoMapper;
using System.Runtime.CompilerServices;
using testAPI.DTOs;
using testAPI.Services.Interfaces;

namespace testAPI.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

     

        public async Task<IQueryable<Category>> GetAll()
        {
            return await _repository.GetAll(OrderByExpression: c=>c.Name , isDescending:true);
        }

        public async Task<Category> GetById(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
        
            var category = await  _repository.GetByIdAsync(id);

            if (category == null) throw new Exception("Not Found");
            return category;
        
        }

        public async Task<Category> Create(CreateCategoryDto createCategoryDto)
        {
            if (createCategoryDto == null) throw new Exception("Not null");

            //Category category = new Category()
            //{
            //    Name = createCategoryDto.Name,
            //};

            Category category = _mapper.Map<Category>(createCategoryDto);
            // birinci hazir gelen ikinci ney emap olunandir 
            await _repository.Create(category);
            await _repository.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Update(int id, UpdateCategoryDto updateCategoryDto)
        {
            if (id <= 0) throw new Exception("Bad Request");

            var existcategory = await _repository.GetByIdAsync(id);

            existcategory.Name = updateCategoryDto.Name;
           
           // existcategory = _mapper.Map<Category>(updateCategoryDto);
            _repository.Update(existcategory);
            await _repository.SaveChangesAsync();
            return existcategory;
        }

        public async void Delete(int id)
        {
            var oldcategory = await _repository.GetByIdAsync(id);
            _repository.Delete(oldcategory);
            await _repository.SaveChangesAsync();       
        }
    }
}
