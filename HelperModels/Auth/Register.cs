﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.HelperModels.Auth
{
    public class Register
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string PersonelPhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
