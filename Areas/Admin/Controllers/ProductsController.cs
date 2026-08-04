using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KhosraviFlowerShop.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace KhosraviFlowerShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        public static string imag;
        private readonly KhosraviFlowerShopContext _context;

        public ProductsController(KhosraviFlowerShopContext context)
        {
            _context = context;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            var khosraviFlowerShopContext = _context.Product.Include(p => p.categorys);
            return View(await khosraviFlowerShopContext.ToListAsync());
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.categorys)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,CategoryId,Title,ShortDescription,Text,Visit,ShowInSlider,Price,Image,Count,CreateDate")] Product product,IFormFile ImgUp)
        {
            if (ModelState.IsValid)
            {
                //changes
                if (ImgUp != null)
                {
                    product.Visit = 0;
                    product.Image = Guid.NewGuid() + Path.GetExtension(ImgUp.FileName);
                    string ImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Products", product.Image);
                    using (var stream = new FileStream(ImagePath, FileMode.Create))
                    {
                        ImgUp.CopyTo(stream);
                    }
                }
                else
                {
                    product.Image = "no-photo.png";
                }
                
                //end
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            imag = product.Image;
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,CategoryId,Title,ShortDescription,Text,Visit,ShowInSlider,Price,Image,Count,CreateDate")] Product product, IFormFile ImgUp)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(ImgUp != null)
                    {
                        if(!string.IsNullOrEmpty(imag) && imag != "no-photo.png")
                        {
                            //start
                            string DeleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Products", imag);
                            if (System.IO.File.Exists(DeleteImagePath))
                            {
                                System.IO.File.Delete(DeleteImagePath);
                            }
                        }
                        product.Image = Guid.NewGuid() + Path.GetExtension(ImgUp.FileName);
                        string ImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Products", product.Image);
                        using (var stream = new FileStream(ImagePath, FileMode.Create))
                        {
                            ImgUp.CopyTo(stream);
                        }
                    }
                    else
                    {
                        product.Image = imag;
                    }
                   //end
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.categorys)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }
}
