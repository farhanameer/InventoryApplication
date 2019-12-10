using InventoryApplication.ContractRepos;
using InventoryApplication.DataCon;
using InventoryApplication.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.ConcreteRepos
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddProduct(Product prdouct)
        {
            await _context.Products.AddAsync(prdouct);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            if (await ProductExist(id))
            {
                _context.Products.Remove(await ProductById(id));
                return true;
            }
            return false;
        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> ProductById(int id)
        {
            if (await ProductExist(id))
            {
                return await _context.Products.Where(x => x.ProductID == id).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<bool> ProductExist(int id)
        {
            var product = await _context.Products.Where(x => x.ProductID == id).FirstOrDefaultAsync();
            if (product!=null)
            {
                return true;
            }
            return false;
        }

        public void SaveChangersAsync()
        {
            _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            return true;
        }
    }
}
