using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.Entities
{
    [Table("tblPurchase")]
    public class Purchase
    {
        [Key]
        public int PurchaseID { get; set; }

        [Required]
        public string PurchaseNo { get; set; }

        [Required]
        public string PO { get; set; }


        public DateTime Date { get; set;}

        [Required]
        public decimal SalesTax { get; set; }

        [Required]
        public decimal Total { get; set; }

        public int ProductID { get; set; }

        public int SupplierID { get; set; }

        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        [ForeignKey("SupplierID")]
        public Supplier Supplier { get; set; }
        public PurchaseDetail PurchaseDetail { get; set; }

        [Required]
        public int ShopID { get; set; }

        [ForeignKey("ShopID")]
        public Shop Shop { get; set; }
    }
}
