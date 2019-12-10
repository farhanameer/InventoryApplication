using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.HelperModels.CategoryModels
{
    public class CategoryDto
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
