using AutoMapper;
using InventoryApplication.Entities;
using InventoryApplication.HelperModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductCreationDto, Product>();
            CreateMap<Product, ProductReturnDto>();
        }
    }
}
