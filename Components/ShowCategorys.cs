using KhosraviFlowerShop.Models;
using KhosraviFlowerShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhosraviFlowerShop.Components
{
    public class ShowCategorys : ViewComponent
    {

        private readonly KhosraviFlowerShopContext _context;

        public ShowCategorys (KhosraviFlowerShopContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View("/Views/Components/ShowCategorys.cshtml", _context.Category.Select(cat=> new CategoryViewModel() { 
                CategoryId=cat.CategoryId,
                Name=cat.Name,
                CategoryCount=cat.products.Count

            }));
        }

    }
}
