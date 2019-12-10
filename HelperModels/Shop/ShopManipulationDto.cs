using InventoryApplication.HelperModels.Location;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.HelperModels.Shop
{
    public class ShopManipulationDto : LocationManipulationDto
    {
        [Required]
        public string ShopName { get; set; }

        public string ShopPhone { get; set; }

        [Required]
        public string GeneralContactEmail { get; set; }
    }
}
