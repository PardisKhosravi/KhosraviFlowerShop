using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KhosraviFlowerShop.Models
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }


        [Display(Name = "محصول")]
        public int ProductId { get; set; }



        [Display(Name = "نام")]
        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
        public string Name { get; set; }


        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "ایمیل معتبر نیست")]
        public string Email { get; set; }


        [Display(Name = "شرح نظر")]
        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        [Display(Name = "تاریخ ")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }


        #region Relation
        [ForeignKey("ProductId")]
        public virtual Product products { get; set; }
        #endregion
    }
}
