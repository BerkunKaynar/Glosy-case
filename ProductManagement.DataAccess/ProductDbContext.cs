using Microsoft.EntityFrameworkCore;
using ProductManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.DataAccess
{
    public class ProductDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=LAPTOP-25JMA1CQ; Database=ProductDb; Integrated Security=true; TrustServerCertificate=True");
        }

        public DbSet<Product> Products { get; set; }
    }
}
