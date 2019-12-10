using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.Entities
{
    [Table("tblInventory")]
    public class Inventory
    {
        [Key]
        public int InventoryID { get; set; }

        [Required]
        public int ItemsLeft { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }

        [Required]
        public int ProductID { get; set; }

        [ForeignKey("ProductID")]
        public Product Product { get; set; }
    }
}
