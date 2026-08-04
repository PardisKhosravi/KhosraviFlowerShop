using KhosraviFlowerShop.Models;
using KhosraviFlowerShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhosraviFlowerShop.Components
{
    public class ShowCategoryInMenu : ViewComponent
    {

        private readonly KhosraviFlowerShopContext _context;

        public ShowCategoryInMenu (KhosraviFlowerShopContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View("/Views/Components/ShowCategoryInMenu.cshtml", _context.Category);
        }

    }
}
