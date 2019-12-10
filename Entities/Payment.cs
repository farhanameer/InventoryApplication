using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.Entities
{
    [Table("tblPayment")]
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required]
        public string CheckNumber { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public DateTime Date { get; set;}

        [Required]
        public int PurchaseID { get; set; }


        [ForeignKey("PurchaseID")]
        public Purchase Purchase { get; set; }
    }
}
