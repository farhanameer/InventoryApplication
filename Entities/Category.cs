using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.Entities
{
    [Table("tblCategory")]
    public class Category
    {
        public int CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public Product Product { get; set; }
    }
}
