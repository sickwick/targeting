using System.Collections.Generic;
using Shop.Storage.Models;

namespace Shop.Storage.Interfaces.Services
{
    public interface IProductService
    {
        public List<Product> GetAllProducts();
        public Product GetProduct(long article);
        public List<Sizes> GetSizes(long article);
        public bool AddNewProduct(Product product);
    }
}