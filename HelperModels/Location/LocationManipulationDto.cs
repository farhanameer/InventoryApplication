using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.HelperModels.Location
{
    public abstract class LocationManipulationDto
    {
        [Required(ErrorMessage ="Street Is Required")]
        
        public string Street { get; set; }



        [Required(ErrorMessage = "City Is Required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Province Is Required")]
        public string Province { get; set; }


        [Required(ErrorMessage = "ZipCode Is Required")]
        public int ZipCode { get; set; }

        [Required(ErrorMessage = "Country Is Required")]
        public string Country { get; set; }
    }
}
