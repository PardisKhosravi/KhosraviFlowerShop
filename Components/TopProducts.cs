using KhosraviFlowerShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhosraviFlowerShop.Components
{
    public class TopProducts : ViewComponent
    {

        private readonly KhosraviFlowerShopContext _context;

        public TopProducts (KhosraviFlowerShopContext context)
        {
            _context = context;
        }



        public IViewComponentResult Invoke(int take=4)
        {
            return View("/Views/Components/TopProducts.cshtml", _context.Product.OrderByDescending(pd=> pd.Visit).Take(take));
        }

    }
}
