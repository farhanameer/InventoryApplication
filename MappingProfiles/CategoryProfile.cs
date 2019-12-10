using AutoMapper;
using InventoryApplication.Entities;
using InventoryApplication.HelperModels.CategoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, Category>().ForMember(x=>x.CategoryID, opt=>opt.Ignore());
            CreateMap<CategoryCreationDto, Category>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryUpdateDto, Category>();
        }
    }
}
