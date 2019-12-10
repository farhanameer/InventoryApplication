using InventoryApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.ContractRepos
{
    public interface ILocation
    {
        Task<bool> AddLocation(Location location);
        Task<bool> DeleteLocation(int id);
        Task<bool> UpdateLocation(Location location);

        Task<Location> GetSingleLocationByID(int id);

        Task<List<Location>> AllLocations();

        Task<bool> LocationExist(int id);
    }
}
