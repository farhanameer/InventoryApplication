using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.Entities
{
    [Table("tblLocation")]
    public class Location
    {
        [Key]
        public int LocationID { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        [MaxLength(5)]
        public int ZipCode { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
