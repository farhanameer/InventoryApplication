using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.Entities
{
    [Table("tblShop")]
    public class Shop
    {
        public int ShopID { get; set; }

        public string ShopName { get; set; }

        [Required]       
        public int LocationID { get; set; }


        [ForeignKey("LocationID")]
        public Location Location { get; set; }

        public string ShopPhone { get; set; }

        [Required]
        public string GeneralContactEmail { get; set; }

        
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
