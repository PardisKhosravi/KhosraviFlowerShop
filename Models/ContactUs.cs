using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhosraviFlowerShop.Models
{
    public class ContactUs
    {
        [Key]
        public int ContactId { get; set; }


        [Display(Name = "شماره تماس")]
        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        [MaxLength(11, ErrorMessage = "{0} نمیتواند بیشتر از {1}کارکتر باشد")]
        [RegularExpression(pattern: "^09[0|1|2|3][0-9]{8}$", ErrorMessage = "لطفا {0} را با فرمت مناسب وارد کنید: 09175562301")]
        public string PhoneNumber { get; set; }



        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "ایمیل معتبر نیست")]
        public string Email { get; set; }



        [Display(Name = "آدرس")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
    }
}
