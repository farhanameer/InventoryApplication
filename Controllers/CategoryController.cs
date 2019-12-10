using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InventoryApplication.ContractRepos;
using InventoryApplication.Entities;
using InventoryApplication.HelperModels.CategoryModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApplication.Controllers
{
    
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AllCategories()
        {
            var categories = await _repo.AllCategories();
            if (categories.Count==0)
            {
                return NotFound("No Categories Were Found");
            }
           
            return Ok(_mapper.Map<List<CategoryDto>>(categories));
        }

        [HttpGet("{CategoryID}", Name ="category")]
        public async Task<IActionResult> SingleCategory(int CategoryID)
        {

            if (CategoryID == 0)
            {
                return BadRequest();
            }
            Category category = await _repo.CategoryByID(CategoryID);
            if (category == null)
            {
                return NotFound("No Category Was Found");
            }
            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryCreationDto category)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }
            var creationCategory = _mapper.Map<Category>(category);
            if (await _repo.AddCategory(creationCategory))
            {
                return CreatedAtRoute("category",new { CategoryID=creationCategory.CategoryID }, _mapper.Map<CategoryDto>(creationCategory));
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute]int id,[FromBody] CategoryUpdateDto category)
        {
            if (!await _repo.CategoryExist(id))
            {
                return NotFound("No Category Was Found");
            }
            var categoryDb = await _repo.CategoryByID(id);
            _mapper.Map(category,categoryDb);
            _repo.SaveChangersAsync();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (!await _repo.CategoryExist(id))
            {
                return NotFound("No Category Was Found To Delete");
            }
            await  _repo.DeleteCategory(id);
            return NoContent();
        }
    }
}