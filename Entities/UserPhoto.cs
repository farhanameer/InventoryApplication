using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApplication.Entities
{
    [Table("tblUserPhoto")]
    public class UserPhoto
    {
        [Key]
        public int UserPhotoID { get; set; }

        [Required]
        public string ImgUrl { get; set; }

        [Required]
        public bool IsDefault { get; set; }

        [Required]
        public string UserID { get; set; }



        [ForeignKey("UserID")]

        public User User { get; set; }

        public string PublicID { get; set; }


    }
}
