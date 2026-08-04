using KhosraviFlowerShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhosraviFlowerShop.Components
{
    public class LastProducts : ViewComponent
    {

        private readonly KhosraviFlowerShopContext _context;

        public LastProducts (KhosraviFlowerShopContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(int take=5)
        {
            return View("/Views/Components/LastProducts.cshtml", _context.Product.OrderByDescending(pd=> pd.CreateDate).Take(take));
        }

    }
}
