using ProductManagement.Business.Abstract;
using ProductManagement.DataAccess.Abstract;
using ProductManagement.DataAccess.Concrete;
using ProductManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;

        public ProductManager()
        {
            _productRepository = new ProductRepository();
        }

        public Product CreateProduct(Product product)
        {
            return _productRepository.CreateProduct(product);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public Product UpdateProduct(Product product)
        {
            return _productRepository.UpdateProduct(product);
        }
    }
}
