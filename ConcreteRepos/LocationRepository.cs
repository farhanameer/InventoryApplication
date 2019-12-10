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
    public class LocationRepository : ILocation
    {
        private readonly DataContext _context;
        public LocationRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddLocation(Location location)
        {
            if (location==null)
            {
                return false;
            }
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Location>> AllLocations()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<bool> DeleteLocation(int id)
        {
            if (id==0)
            {
                return false;
            }
            var location = await GetSingleLocationByID(id);
            if (location==null)
            {
                return false;
            }
            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Location> GetSingleLocationByID(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var location = await _context.Locations.Where(x => x.LocationID == id).FirstOrDefaultAsync();
            if (location == null)
            {
                return null;
            }
            return location;
        }

        public async Task<bool> UpdateLocation(Location location)
        {
            await _context.SaveChangesAsync();
            return true;    
        }


        public async Task<bool> LocationExist(int id)
        {
            var location = await _context.Locations.Where(x => x.LocationID == id).FirstOrDefaultAsync();
            if (location==null)
            {
                return false;
            }
            return true;
        }

    }
}
