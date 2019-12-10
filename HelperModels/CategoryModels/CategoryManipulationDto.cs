using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.HelperModels.CategoryModels
{
    public abstract class CategoryManipulationDto
    {
        [Required(ErrorMessage = "Category Name cann't be empty"), MaxLength(10, ErrorMessage = "Cann't be more than 10 characters")]
        public string CategoryName { get; set; }
    }
}
