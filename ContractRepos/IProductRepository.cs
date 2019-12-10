using InventoryApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.ContractRepos
{
    public interface IProductRepository
    {
        Task<bool> AddProduct(Product prdouct);
        Task<List<Product>> GetAllProduct();
        Task<Product> ProductById(int id);
        Task<bool> ProductExist(int id);
        Task<bool> DeleteProduct(int id);
        Task<bool> UpdateProduct(Product product);
        void SaveChangersAsync();
    }
}
