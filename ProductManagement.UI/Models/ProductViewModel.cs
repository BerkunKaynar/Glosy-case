using ProductManagement.Entities;

namespace ProductManagement.UI.Models
{
    public class ProductViewModel
    {
        public int id { get; set; }
        public string productName { get; set; }
        public int stock { get; set; }
        public decimal price { get; set; }
    }

    }

