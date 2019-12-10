using AutoMapper;
using InventoryApplication.Entities;
using InventoryApplication.HelperModels.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Register, User>();
            CreateMap<Register, Location>();
        }
    }
}
