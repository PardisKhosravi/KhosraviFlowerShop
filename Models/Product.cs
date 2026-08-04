using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KhosraviFlowerShop.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }


        [Display(Name = "دسته بندی")]
        public int CategoryId { get; set; }



        [Display(Name = "عنوان محصول")]
        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
        public string Title { get; set; }



        [Display(Name = "توضیح مختصر محصول")]
        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }


        [Display(Name = "شرح محصول")]
        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }


        [Display(Name = "تعداد بازدید")]
        public int Visit { get; set; }


        [Display(Name = "نمایش در اسلایدر")]
        public bool ShowInSlider { get; set; }


        [Display(Name = "قیمت")]
        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        [Range(1, int.MaxValue, ErrorMessage = "قیمت نمی تواند 0 باشد")]
        public int Price { get; set; }


        [Display(Name = "تصویر")]
        public string Image { get; set; }


        [Display(Name = "تعداد")]
        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        [Range(1, int.MaxValue, ErrorMessage = "نعداد نمی تواند 0 باشد")]
        public int Count { get; set; }


        [Display(Name = "تاریخ ایجاد")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime CreateDate { get; set; }

        #region Relation
        [ForeignKey("CategoryId")]
        public virtual Category categorys { get; set; }
        public virtual ICollection<Comments> comments { get; set; }

        #endregion
    }
}



