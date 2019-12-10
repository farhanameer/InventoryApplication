using InventoryApplication.ContractRepos;
using InventoryApplication.DataCon;
using InventoryApplication.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace InventoryApplication.ConcreteRepos
{
    public class ShopRepository : IShopRepository
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        
        public ShopRepository(DataContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<bool> AddShop(Shop shop)
        {
            if (shop==null)
            {
                return false;
            }
            await _context.Shops.AddAsync(shop);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteShop(int id)
        {
            if (id==0)
            {
                return false;
            }
            if (await ShopExist(id))
            {
                _context.Shops.Remove(await GetSingleShop(id,null));
               await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Shop>> GetAllShops()
        {
            var shops = await _context.Shops.ToListAsync();
            return shops;
        }

        public async Task<Shop> GetSingleShop(int id,string? userId)
        {
            if (userId!=null)
            {
                return await _context.Shops.Where(x => x.ShopID == id && x.UserId == userId).Include(x=>x.Location).FirstOrDefaultAsync();
            }
            if (await ShopExist(id))
            {
                return await _context.Shops.Where(x => x.ShopID == id).Include(x=>x.Location).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<Shop> ShopByUserId(string id)
        {
            if (id==null)
            {
                return null;
            }
            var shop = await _context.Shops.Where(x => x.UserId == id).FirstOrDefaultAsync();
            return shop;
        }

        public async Task<bool> ShopExist(int id)
        {
            if (id==0)
            {
                return false;
            }
            var shop = await _context.Shops.Where(x => x.ShopID == id).FirstOrDefaultAsync();
            if (shop==null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> ShopExistByUserID(string id)
        {
            var shop = await _context.Shops.Where(x => x.UserId == id).FirstOrDefaultAsync();
            if (shop==null)
            {
                return false;
            }
            return true;
        }

        public async Task<int> ShopIdByUserId(string id)
        {
            var shop = await ShopByUserId(id);
            return shop.ShopID;
        }

        public async Task<bool> UpdateShop(Shop shop)
        {
            await _context.SaveChangesAsync();
            return true;
        }

        


    }
}
