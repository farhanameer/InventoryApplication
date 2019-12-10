using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.HelperModels.Shop
{
    public class ShopReturnDto
    {
        public int ShopID { get; set; }
        public string ShopName { get; set; }

        public string ShopPhone { get; set; }

        
        public string GeneralContactEmail { get; set; }

        public string Address { get; set; }
    }
}
