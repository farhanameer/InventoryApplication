using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.HelperModels.Cloudinary
{
    public class CloudinaryPhoto
    {
        public string Url { get; set; }

        public IFormFile File { get; set; }

        public string PublicID { get; set; }

        
    }
}
