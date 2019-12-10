using AutoMapper;
using InventoryApplication.Entities;
using InventoryApplication.HelperModels.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.MappingProfiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Location, LocationReturnDto>().ForMember(des => des.Address, opt => opt.MapFrom(x => string.Format($"{x.Street}, {x.City} , {x.ZipCode} , {x.Country}")));

            CreateMap<LocationCreationDto, Location>();

            CreateMap<LocationUpdateionDto, Location>();
        }
    }
}
