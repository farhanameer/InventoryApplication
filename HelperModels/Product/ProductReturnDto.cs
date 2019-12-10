using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.HelperModels.Product
{
    public class ProductReturnDto
    {
        
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string ProductCode { get; set; }

        public string ShopName { get; set; }

        public string CategoryName { get; set; }
    }
}
