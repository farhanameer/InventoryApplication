using InventoryApplication.Entities;
using InventoryApplication.HelperModels.CategoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.ContractRepos
{
   public interface ICategoryRepository
    {
        Task<bool> AddCategory(Category category);
        Task<bool> CategoryExist(int id);

        void UpdateCategory(CategoryUpdateDto category);

        Task<bool> DeleteCategory(int id);

        Task<Category> CategoryByID(int id);
        Task<List<Category>> AllCategories();

        void SaveChangersAsync();
    }
}
