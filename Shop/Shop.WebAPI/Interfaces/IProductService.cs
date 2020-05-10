using System.Collections.Generic;
using Shop.Database.Models;

namespace Shop.WebAPI.Interfaces
{
    public interface IProductService
    {
        public List<Product> GetAllProducts();
        public Product GetProduct(long article);
        public List<Sizes> GetSizes(long article);
        public bool AddNewProduct(Product product);
    }
}