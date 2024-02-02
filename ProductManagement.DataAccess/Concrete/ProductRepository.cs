using ProductManagement.DataAccess.Abstract;
using ProductManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.DataAccess.Concrete
{
    public class ProductRepository : IProductRepository
    {
        public Product CreateProduct(Product product)
        {
            using (var productDbContext = new ProductDbContext())
            {
                productDbContext.Products.Add(product);
                productDbContext.SaveChanges();
                return product;
            }
        }

        public void DeleteProduct(int id)
        {
            using (var productDbContext = new ProductDbContext())
            {
                var deleted = GetProductById(id);
                productDbContext.Products.Remove(deleted);
                productDbContext.SaveChanges();
            }
        }

        public List<Product> GetAllProducts()
        {
            using (var productDbContext = new ProductDbContext())
            {
                return productDbContext.Products.ToList();
            }
        }

        public Product GetProductById(int id)
        {
            using (var productDbContext = new ProductDbContext())
            {
                return productDbContext.Products.Find(id);
            }
        }

        public Product UpdateProduct(Product product)
        {
            using (var productDbContext = new ProductDbContext())
            {
                productDbContext.Products.Update(product);
                productDbContext.SaveChanges();
                return product;
            }
        }
    }
}
