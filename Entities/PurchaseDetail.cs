using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.Entities
{
    [Table("tblPurchaseDetail")]
    public class PurchaseDetail
    {
        [Key]
        public int PurchaseDetailID { get; set; }

        [Required]
        public decimal CostPerUnit { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int PurchaseID { get; set; }

        


        [ForeignKey("PurchaseID")]
        public Purchase Purchase { get; set; }


        


    }
}
