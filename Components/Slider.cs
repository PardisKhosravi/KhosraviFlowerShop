using KhosraviFlowerShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhosraviFlowerShop.Components
{
    public class Slider : ViewComponent
    {

        private readonly KhosraviFlowerShopContext _context;

        public Slider (KhosraviFlowerShopContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(int take=5)
        {
            return View("/Views/Components/Slider.cshtml", _context.Product.Where(pd=> pd.ShowInSlider == true).Take(take));
        }

    }
}
