using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KhosraviFlowerShop.Models;

namespace KhosraviFlowerShop.Models
{
    public class KhosraviFlowerShopContext : DbContext
    {
        public KhosraviFlowerShopContext (DbContextOptions<KhosraviFlowerShopContext> options)
            : base(options)
        {
        }

        public DbSet<KhosraviFlowerShop.Models.AboutUs> AboutUs { get; set; }

        public DbSet<KhosraviFlowerShop.Models.Category> Category { get; set; }

        public DbSet<KhosraviFlowerShop.Models.Comments> Comments { get; set; }

        public DbSet<KhosraviFlowerShop.Models.ContactUs> ContactUs { get; set; }

        public DbSet<KhosraviFlowerShop.Models.Product> Product { get; set; }
    }
}
