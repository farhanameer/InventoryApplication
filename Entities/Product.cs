using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.Entities
{
    [Table("tblProduct")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }


        [Required]
        public string ProductName { get; set; }


        [Required]
        public string ProductCode { get; set; }


        public int ShopID { get; set; }

        [ForeignKey("ShopID")]
        public Shop Shop { get; set; }

        
        public int CategoryID { get; set; }


        [ForeignKey("CategoryID")]
        public Category Category { get; set; }

        public List<ProductSupplier> ProductSupplier { get; set; }


        
        
    }
}
