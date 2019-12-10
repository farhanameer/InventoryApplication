using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.HelperModels.Auth
{
    public class LoginDto
    {
        [Required]
        public string userName { get; set; }

        public string Password { get; set; }
    }
}
