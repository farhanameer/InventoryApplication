using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.Entities
{
    [Table("tblSale")]
    public class Sale
    {
        [Key]
        public int SaleID { get; set; }

        [Required]
        public string SaleNumber { get; set; }

        public DateTime Date { get; set; }
        [Required]
        public string PO { get; set; }
        [Required]
        public decimal SalesTax { get; set; }
        [Required]
        public decimal Total { get; set; }

        public SaleDetail SaleDetail { get; set; }
    }
}
