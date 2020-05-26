using System.Collections.Generic;
using Shop.Core.Models;

namespace Shop.Core.Interfaces.Services
{
    public interface IProductService
    {
        public List<Product> GetAllProducts();
        public Product GetProduct(long article);
        public List<Sizes> GetSizes(long article);
        public bool AddNewProduct(Product product);
    }
}