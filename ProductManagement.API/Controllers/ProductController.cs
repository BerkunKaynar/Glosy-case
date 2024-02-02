using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Business.Abstract;
using ProductManagement.Business.Concrete;
using ProductManagement.Entities;

namespace ProductManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController()
        {
            _productService = new ProductManager();
        }

        [HttpGet]
        public List<Product> GetProducts()
        {
            return _productService.GetAllProducts();
        }

        [HttpGet("{id}")]
        public Product GetProductsById(int id)
        {
            return _productService.GetProductById(id);
        }

        [HttpPost]
        public Product CreatedProduct(Product product)
        {
            return _productService.CreateProduct(product);
        }

        [HttpPut]
        public Product UptatedProduct(Product product)
        {
            return _productService.UpdateProduct(product);
        }

        [HttpDelete("{id}")]
        public void DeletedProduct(int id)
        {
            _productService.DeleteProduct(id);
        }
    }
}
