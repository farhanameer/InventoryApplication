using InventoryApplication.ContractRepos;
using InventoryApplication.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.DataCon
{
    public class Seed
    {
        private readonly UserManager<Entities.User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILocation _location;
        public Seed(UserManager<Entities.User> userManager, RoleManager<IdentityRole> roleManager,ILocation location)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _location = location;
        }

        public void SeedUser()
        {
            if (!_userManager.Users.Any())
            {
                
                var user = new Entities.User
                {
                    Email = "admin@gmail.com",
                    UserName = "Admin@gmail.com",
                    FirstName="Farhan",
                    LastName="Ameer",
                    Location =new Location
                    {
                        Street="Lahore Avenu",
                    City="Lahore",
                    Province="Pubnjab",
                    ZipCode=1542,
                    Country="Pakistan"
                    },
                    PersonelPhoneNumber="455521"
                };
                var role = new IdentityRole
                {
                    Name = "Admin"
                };
                _roleManager.CreateAsync(role).Wait();
                _userManager.CreateAsync(user, "Admin@123L").Wait();
                _userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }
    }
}
