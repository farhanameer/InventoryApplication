using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.HelperModels.Product
{
    public class ProductCreationDto
    {
        

        [Required]
        public string ProductName { get; set; }


        [Required]
        public string ProductCode { get; set; }


        public int ShopID { get; set; }

        [Required]
        public int CategoryID { get; set; }
    }
}
