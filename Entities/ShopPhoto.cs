using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.Entities
{
    [Table("tblShopPhoto")]
    public class ShopPhoto
    {
        [Key]
        public int ShopPhotoID { get; set; }

        [Required]
        public string ShopUrl { get; set; }

        [Required]
        public bool IsDefault { get; set; }

        [Required]
        public int ShopID { get; set; }

        [ForeignKey("ShopID")]
        public Shop Shop { get; set; }
    }
}
