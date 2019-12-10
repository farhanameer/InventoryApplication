using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.Entities
{
    
    public class User : IdentityUser
    {
        

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        

        [Required]
        public int LocationID { get; set; }

        [ForeignKey("LocationID")]
        public Location Location { get; set; }

        
        public string PersonelPhoneNumber { get; set; }

        public Supplier Supplier { get; set; }
    }
}
