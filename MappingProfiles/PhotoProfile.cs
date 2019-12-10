using AutoMapper;
using InventoryApplication.Entities;
using InventoryApplication.HelperModels.Cloudinary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.MappingProfiles
{
    public class PhotoProfile : Profile
    {
        public PhotoProfile()
        {
            CreateMap<CloudinaryPhoto, UserPhoto>();
        }
    }
}
