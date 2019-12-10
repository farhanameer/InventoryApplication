using InventoryApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.ContractRepos
{
    public interface IShopRepository
    {
        Task<bool> AddShop(Shop shop);
        Task<Shop> GetSingleShop(int id,string? userId);
        Task<bool> DeleteShop(int id);
        Task<bool> ShopExist(int id);
        Task<bool> UpdateShop(Shop shop);
        Task<List<Shop>> GetAllShops();
        Task<bool> ShopExistByUserID(string id);

        Task<Shop> ShopByUserId(string id);
        Task<int> ShopIdByUserId(string id);

        
    }
}
