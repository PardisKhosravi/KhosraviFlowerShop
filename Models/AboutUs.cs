using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhosraviFlowerShop.Models
{
    public class AboutUs
    {
        [Key]
        public int AboutId { get; set; }


        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
