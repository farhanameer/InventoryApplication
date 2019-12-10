using AutoMapper;
using InventoryApplication.ContractRepos;
using InventoryApplication.DataCon;
using InventoryApplication.Entities;
using InventoryApplication.HelperModels.CategoryModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.ConcreteRepos
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CategoryRepository(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddCategory(Category category)
        {
            if (category==null)
            {
                return false;
            }
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CategoryExist(int id)
        {
            var category =await  _context.Categories.Where(x => x.CategoryID == id).FirstOrDefaultAsync();

            if (category==null)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Category>> AllCategories()
        {
            List<Category> categories = await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category> CategoryByID(int id)
        {
            var category = await _context.Categories.Where(x => x.CategoryID == id).FirstOrDefaultAsync();
            return category;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            if (await CategoryExist(id))
            {
                _context.Remove(await CategoryByID(id));
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public void UpdateCategory(CategoryUpdateDto category)
        { 
        }


        public void SaveChangersAsync()
        {
            _context.SaveChangesAsync();
        }
    }
}
