using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.Entities
{
    [Table("tblSaleDetail")]
    public class SaleDetail
    {
        [Key]
        public int SaleDetailID { get; set; }


        public int ProductID { get; set; }

        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal PricePerUnit { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public int SaleID { get; set; }
        [ForeignKey("SaleID")]
        public Sale Sale { get; set; }
    }
}
