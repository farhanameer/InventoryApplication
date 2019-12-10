using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.Entities
{
    [Table("tblSupplier")]
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        [Required]
        public string UserID { get; set;}


        public List<ProductSupplier> ProductSupplier { get; set; }

        public PurchaseDetail PurchaseDetail { get; set; }


        [ForeignKey("UserID")]
        public User User { get; set; }
    }
}
