using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhosraviFlowerShop.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }


        [Display(Name = "عنوان دسته بندی")]
        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد")]
        public string Name { get; set; }


        #region Relation
        public virtual ICollection<Product> products { get; set; }
        #endregion
    }
}
