using AutoMapper;
using InventoryApplication.Entities;
using InventoryApplication.HelperModels.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.MappingProfiles
{
    public class ShopProfile : Profile
    {
        public ShopProfile()
        {
            CreateMap<ShopCreationDto,Shop>();
            CreateMap<ShopCreationDto, Location>();
            CreateMap<Shop, ShopReturnDto>().ForMember(des=>des.Address,op=>op.MapFrom(x=>string.Format($"{x.Location.Street} , {x.Location.City}, {x.Location.ZipCode}, {x.Location.Province}, {x.Location.Country}")));
            CreateMap<ShopUpdationDto, Shop>();
        }
    }
}
